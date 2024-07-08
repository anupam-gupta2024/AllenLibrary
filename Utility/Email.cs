using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AllenLibrary.Classes;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace AllenLibrary.Utility
{
    public class Email
    {
        private static string SendHTMLEmail(EmailTemplate emailTemplate)
        {
            try
            {
                Thread sms1 = new Thread(delegate()
                {
                    MailMessage myMessage = new MailMessage();
                    myMessage.From = new MailAddress(emailTemplate.FromEmail, emailTemplate.MailDisplay);
                    myMessage.To.Add(emailTemplate.MailTo);
                    if (!String.IsNullOrEmpty(emailTemplate.BCC.Trim())) myMessage.Bcc.Add(emailTemplate.BCC);
                    myMessage.Body = emailTemplate.Body;
                    myMessage.IsBodyHtml = true;
                    myMessage.Subject = emailTemplate.Subject;

                    SmtpClient smtp = new SmtpClient(emailTemplate.SmtpClient);
                    smtp.Credentials = new NetworkCredential(emailTemplate.FromEmail, emailTemplate.MailPassword);
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(myMessage);
                });

                sms1.IsBackground = true;
                sms1.Start();

                return "";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Gets the email template. Replacement parameters in the template are replaced with their appropriate values. The data
        /// in the template can be used to construct an e-mail.
        /// </summary>
        /// <param name="template">The template to retrieve.</param>
        /// <param name="userName">The name of the user associated with the template.</param>
        /// <param name="email">The email of the user associated with the template.</param>
        /// <returns>Returns an e-mail template.</returns>
        private static EmailTemplate GetEmailTemplate(EmailTemplate emailTemplate)
        {
            // Step 1: Get subject and body from text file and assign to fields.
            using (StreamReader sr = File.OpenText(emailTemplate.Path))
            {
                while (sr.Peek() >= 0)
                {
                    string lineText = sr.ReadLine().Trim();

                    if (lineText == "[Subject]")
                        emailTemplate.Subject = sr.ReadLine();

                    if (lineText == "[BCC]")
                        emailTemplate.BCC = sr.ReadLine();

                    if (lineText == "[Body]")
                        emailTemplate.Body = sr.ReadToEnd();
                }
            }

            // Step 2: Update replacement parameters with real values.
            foreach (var p in emailTemplate.parameters)
            {
                if (emailTemplate.Subject.Contains(p.Key))
                    emailTemplate.Subject = emailTemplate.Subject.Replace(p.Key, p.Value);
                if (emailTemplate.Body.Contains(p.Key))
                    emailTemplate.Body = emailTemplate.Body.Replace(p.Key, p.Value);
            }

            return emailTemplate;
        }

        public static string SendEmail(EmailTemplate emailTemplate, bool sendOnBackgroundThread)
        {
            if (!ValidateInputData.ValidateEmail(emailTemplate.MailTo, true))
                throw new ArgumentNullException("MailTo");
            else if (string.IsNullOrEmpty(emailTemplate.Path))
                throw new ArgumentNullException("Template Path");

            emailTemplate = GetEmailTemplate(emailTemplate);

            // Because sending the e-mail takes a long time, spin off a thread to send it, unless caller specifically doesn't want to.
            if (sendOnBackgroundThread)
            {
                Task.Factory.StartNew(() => SendHTMLEmail(emailTemplate));
                return "";
            }
            else
            {
                return SendHTMLEmail(emailTemplate);
            }
        }
    }
}
