using Microsoft.AspNetCore.Identity.UI.Services;

namespace AutorizationAunthentication.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            // Реализовать электронную почту

            return Task.CompletedTask;
        }
    }
}
