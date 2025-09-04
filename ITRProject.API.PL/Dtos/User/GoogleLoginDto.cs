using System.ComponentModel.DataAnnotations;

namespace ITRProject.API.PL.Dtos.User
{
    public class GoogleLoginDto
    {
        [Required]
        public string IdToken { get; set; }
    }
}