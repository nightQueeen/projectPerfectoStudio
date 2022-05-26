using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SendGrid; // using SendGrid's C# Library
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace ProjectPS
{
    public class sendGrid
    {
        private static void Main()
        {
            //string email = "mail";
            //string name = "name";
            //Execute(email, name).Wait();
        }

         public static async Task Execute(string email, string name, string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("st3191430@kshapira.ort.org.il", "perfectoStudio");
            var subject = "perfectoStudio";
            var to = new EmailAddress(email, name);
            var plainTextContent = "<strong>בקנייה ראשונה יש  הנחה של 15%!</strong>" + message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            client.SendEmailAsync(msg);
        }
    }
}