using System.Net;
using System.Net.Mail;

namespace WebApp.Utils
{
    /// <summary>
    ///  Emails handling interface
    /// </summary>
    public interface IEmailHandler
    {
        void SendEmail(string recipient, string subject, string body);

        void SendEmail(MailMessage message);
    }

    /// <summary>
    ///  Emails handling class
    /// </summary>
    public class EmailHandler : IEmailHandler
    {
        private readonly SmtpClient _smtpClient;

        public SmtpClient SmtpClient { get { return _smtpClient; } }

        public string SenderEmail { get; set; }

        public string SenderName { get; set; }

        /// <summary>
        ///  EmailHandler constructor
        /// </summary>
        /// <param name="smtpClient">SmtpClient object</param>
        /// <param name="senderEmail">Sender email</param>
        /// <param name="senderName">Shown sender name</param>
        public EmailHandler(SmtpClient smtpClient, string senderEmail, string senderName = "")
        {
            _smtpClient = smtpClient;
            SenderEmail = senderEmail;
            SenderName = senderName;
        }

        /// <summary>
        ///  EmailHandler constructor
        /// </summary>
        /// <param name="smtpHost">SMTP host</param>
        /// <param name="smtpPort">SMTP post</param>
        /// <param name="smtpUsername">SMTP username</param>
        /// <param name="smtpPassword">SMTP password</param>
        /// <param name="senderEmail">Sender email</param>
        /// <param name="senderName">Shown sender name</param>
        public EmailHandler(string smtpHost,
                            int smtpPort,
                            string smtpUsername,
                            string smtpPassword,
                            string senderEmail,
                            string senderName = "")
        {
            //creating smtp client
            _smtpClient = new SmtpClient()
            {
                Host = smtpHost,
                Port = smtpPort,
                Credentials = new NetworkCredential(
                    smtpUsername,
                    smtpPassword
                )
            };

            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtpClient.EnableSsl = true;

            SenderEmail = senderEmail;
            SenderName = senderName;
        }

        /// <summary>
        ///  Sends email
        /// </summary>
        /// <param name="recipient">Recipient email address</param>
        /// <param name="subject">Email subject</param>
        /// <param name="body">Email body</param>
        public void SendEmail(string recipient, string subject, string body)
        {
            MailMessage mail = new MailMessage();

            //setting email data
            mail.Body = body;
            mail.Subject = subject;
            mail.From = new MailAddress(SenderEmail, SenderName);
            mail.To.Add(new MailAddress(recipient));

            SendEmail(mail);
        }

        /// <summary>
        ///  Sends email
        /// </summary>
        /// <param name="message">Message object</param>
        public void SendEmail(MailMessage message)
        {
            //ckecking if Sender is already set
            if (message.From == null)
            {
                message.From = new MailAddress(SenderEmail, SenderName);
            }

            //sending email
            SmtpClient.Send(message);
        }
    }
}
