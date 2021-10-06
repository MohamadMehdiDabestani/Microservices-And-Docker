using System.Net;
using Microsoft.Extensions.Options;
using Ordering.Application.Contracts.Infrastracture;
using Ordering.Application.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Mail
{
    class EmailService : IEmailRepo
    {
        public EmailSettings _emailSettings { get; set; }

        public EmailService(IOptions<EmailSettings> opt)
        {
            _emailSettings = opt.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailbody = email.Body;
            var from = new EmailAddress()
            {
                Email = _emailSettings.FromAddres,
                Name = _emailSettings.FromName
            };
            var msg = MailHelper.CreateSingleEmail(from, to, subject, emailbody, emailbody);
            var response = await client.SendEmailAsync(msg);
            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }
    }
}
