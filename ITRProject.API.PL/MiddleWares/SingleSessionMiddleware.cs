using ITR.API.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ITRProject.API.PL.MiddleWares
{
    public class SingleSessionMiddleware
    {
        private readonly RequestDelegate _next;

        public SingleSessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                using var scope = serviceProvider.CreateScope();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var tokenId = context.User.FindFirstValue("tokenId");

                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(tokenId))
                {
                    var user = await userManager.FindByIdAsync(userId);
                    if (user != null && user.CurrentTokenId != tokenId)
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("You have been logged out because your account was used in another device.");
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
}
