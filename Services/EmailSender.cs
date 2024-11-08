using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace AutorizationAunthentication.Services
{
    public class EmailSender : IEmailSender
    {
        
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailSender> _logger;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _fromEmail;
        private readonly string _password;

        public EmailSender(IConfiguration configuration, ILogger<EmailSender> logger)
        {
            _configuration = configuration;
            _logger = logger;
            
            _smtpServer = _configuration["EmailSettings:SmtpServer"];
            _smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
            _fromEmail = _configuration["EmailSettings:FromEmail"];
            _password = _configuration["EmailSettings:Password"];
            
            
        }
        
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            try
            {
                using var message = new MailMessage()
                {
                    From = new MailAddress(_fromEmail),
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true
                };
                
                message.To.Add(new MailAddress(email));

                using var client = new SmtpClient(_smtpServer, _smtpPort)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(_fromEmail, _password)
                };
                
                await client.SendMailAsync(message);
                
                _logger.LogInformation($"Email sent successfully to {email}");

            }
            catch (Exception e)
            {
                _logger.LogError($"Email sending failed to {email}. Error: {e.Message}");
                throw;
            }
            
        }
    }
}
