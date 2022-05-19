using IT_Career.GR.Core.Services.Abstractions;
using IT_Career_GR.Common.Models.Settings;
using IT_Career_GR.Common.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IT_Career.GR.Core.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpClient _smtp;
        private readonly EmailCredentialSettings _emailCredential;
        private readonly ICustomLocalizer _localizer;
        public EmailSender(IConfiguration configuration, ICustomLocalizer localizer)
        {
            _localizer = localizer;
            _emailCredential = configuration.GetSection(nameof(EmailCredentialSettings)).Get<EmailCredentialSettings>();
            _smtp = new SmtpClient()
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = new NetworkCredential(_emailCredential.Email, _emailCredential.Password)
            };
        }

        public async Task SendAccountConfirmationEmail(string receiver, string confirmationLink)
        {
            if (string.IsNullOrEmpty(receiver) || string.IsNullOrEmpty(confirmationLink) || _emailCredential is null) 
            {
                throw new ArgumentNullException();
            }
            MailMessage mailMessage = new MailMessage() 
            {
                From = new MailAddress(_emailCredential.Email),
                Subject = _localizer["AccountConfirmationEmailSubject"],
                Body = $"<h4>{confirmationLink}</h4>",
                IsBodyHtml = true
            };
            mailMessage.To.Add(receiver);
            await Task.Run(() =>
            {
                _smtp.Send(mailMessage);
            });
        }

        public async Task SendPasswordRecoveryEmail(string receiver, string recoveryLink)
        {
            if (string.IsNullOrEmpty(receiver) || string.IsNullOrEmpty(recoveryLink) || _emailCredential is null)
            {
                throw new ArgumentNullException();
            }
            throw new NotImplementedException();
        }
    }
}
