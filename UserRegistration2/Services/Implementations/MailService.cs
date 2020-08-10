using AutoMapper.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace UserRegistration1.Services.Implementations
{
    public class MailService : IMailService
    {
        public async Task SendMail(string toEmail, string subject, string content)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("htshmadgulkar@gmail.com", "SE2 UserRegistration");
            //var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(toEmail);
            //  var plainTextContent = "and easy to do anywhere, even with C#";
            // var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
