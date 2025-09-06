using ITR.API.DAL.Models;
using System.Net.Mail;
using System.Net;

namespace ITRProject.API.PL.Helpers
{
    public static class EmailSettings
    {
        public static void SendEmail(Emails email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("itrgroup67@gmail.com", "cmnhqwqnvgmbwqpe");

            var mailMessage = new MailMessage
            {
                From = new MailAddress("itrgroup67@gmail.com", "ITR Group"),
                Subject = email.Subject,
                Body = email.Body,
                IsBodyHtml = true // ✅ مهم جدا علشان يطبق الاستايل
            };

            mailMessage.To.Add(email.To);

            client.Send(mailMessage);



        }
    }
}
