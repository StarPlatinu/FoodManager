using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace FoodManager.Utils
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //var client = new SendGridClient(SendGridSecret);
            //var from = new EmailAddress("thanhvp1509@gmail.com", "Food Manager");
            //var to = new EmailAddress(email);
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
            //return client.SendEmailAsync(msg);

            return Task.CompletedTask;
        }
    }
}
