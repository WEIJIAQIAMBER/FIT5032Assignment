using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FIT5032Assignment.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents, String AttachmentAddress, String AttachmentName)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            if (AttachmentAddress != null && AttachmentName != null)
            {
                var bytes = File.ReadAllBytes(AttachmentAddress);
                var Attachment = Convert.ToBase64String(bytes);
                msg.AddAttachment(AttachmentName, Attachment);
            }
            var response = client.SendEmailAsync(msg);

        }
        public void SendFirstEmail(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "travel plan team");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p style='font-weight:bold;'>Dear customer,</p><p>" + contents + "</p><hr/><p> Best Regards,</p><p>tour plan team";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

    }
}