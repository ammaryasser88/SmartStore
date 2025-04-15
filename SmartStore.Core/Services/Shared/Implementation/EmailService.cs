using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Configuration;
using SmartStore.Core.Services.Shared.Abstraction;

namespace SmartStore.Core.Services.Shared.Implementation
{

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // الحصول على إعدادات البريد الإلكتروني من appsettings.json
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var port = int.Parse(_configuration["EmailSettings:Port"]);
            var senderEmail = _configuration["EmailSettings:Email"];
            var senderPassword = _configuration["EmailSettings:Password"];

            var smtpClient = new SmtpClient(smtpServer)
            {
                Port = port,
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true, // تأكد من أن الاتصال آمن
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }

}
