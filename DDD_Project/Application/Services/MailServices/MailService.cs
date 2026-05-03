using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Net.Mail;

namespace Application.Services.MailServices
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMail(MailMessage email)
        {
            var from = _configuration["EmailSettings:Email"];
            var password = _configuration["EmailSettings:Password"];
            var host = _configuration["EmailSettings:Host"];
            var port = int.Parse(_configuration["EmailSettings:Port"]);

            var fromMail = new MailboxAddress("Abhishek", from);

            var message = new MimeMessage();

            message.From.Add(fromMail);

            if (string.IsNullOrWhiteSpace(email.To))
                throw new Exception("Recipient email is empty");

            message.To.Add(MailboxAddress.Parse(email.To));

            message.Subject = email.Subject;

            message.Body = new TextPart("html")
            {
                Text = email.Body
            };

            using var client = new MailKit.Net.Smtp.SmtpClient();

            await client.ConnectAsync(host, port,
                MailKit.Security.SecureSocketOptions.StartTls);

            await client.AuthenticateAsync(from, password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}