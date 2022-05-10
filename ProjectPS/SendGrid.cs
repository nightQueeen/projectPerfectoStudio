using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace ProjectPS
{
    internal class sendGrid
    {
        private static void Main()
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("mayakatz03@gmail.com", "perfectoStudio");
            var subject = "perfectoStudio succssful register";
            var to = new EmailAddress("test@example.com", "Example User");
            var plainTextContent = "text paragraph";
            var htmlContent = "<strong>text paragraph</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}