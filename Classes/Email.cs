using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Classes
{
    public class EmailTemplate
    {
        /// <summary>
        /// The e-mail Template Path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The e-mail MailTo.
        /// </summary>
        public string MailTo { get; set; }

        /// <summary>
        /// The e-mail subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The e-mail BCC.
        /// </summary>
        public string BCC { get; set; }

        /// <summary>
        /// The e-mail body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Credential
        /// </summary>
        public string FromEmail { get; set; }
        public string MailPassword { get; set; }
        public string SmtpClient { get; set; }
        public string MailDisplay { get; set; }


        public Dictionary<string, string> parameters { get; set; }
    }
}
