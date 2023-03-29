using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Business.Utils
{
    public class EmailSender : IEmailSender
    {
        private string SmtpHost = "smtp.gmail.com";
        private string SmtpPort = "25";
        private string SmtpTimeout = "1000000";
        private bool EnableSSL = true;
        private string SystemEmailPassword = "Web2021@";
        private string SystemEmailAddress = "info@tnrservices.co.uk";
        private string SystemSenderName = "TNR services";
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }
        public SmtpClient LoadConfigSmtpClient()
        {
            throw new NotImplementedException();
        }

        public void SendEmail(string toEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            SendEmail(toEmailAddress, null, null, subject, message, isBodyHtml);
        }

        public void SendEmail(string toEmailAddress, string senderName, string subject, string message, bool isBodyHtml = false)
        {
            SendEmail(toEmailAddress, senderName, null, subject, message, isBodyHtml);
        }

        public void SendEmail(string toEmailAddress, string senderName, string receiverName, string subject, string message, bool isBodyHtml = false)
        {
            SmtpClient client = BVSmtpClient();
            senderName = string.IsNullOrEmpty(senderName) ? SystemSenderName : senderName;
            MailMessage mailMessage = CreateMessage(toEmailAddress, senderName, receiverName, subject, message, isBodyHtml);
            client.Send(mailMessage);
        }

        public async Task SendEmailAsync(string toEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            await Task.Run(() =>
            {
                SendEmail(toEmailAddress, subject, message, isBodyHtml);
            });
        }

        public async Task SendEmailAsync(string toEmailAddress, string senderName, string subject, string message, bool isBodyHtml = false)
        {
            await Task.Run(() =>
            {
                SendEmail(toEmailAddress, senderName, subject, message, isBodyHtml);
            });
        }

        public async Task SendEmailAsync(string toEmailAddress, string senderName, string receiverName, string subject, string message, bool isBodyHtml = false)
        {
            await Task.Run(() =>
            {
                SendEmail(toEmailAddress, senderName, receiverName, subject, message, isBodyHtml);
            });
        }

        public async Task SendEmailAsyncSmtp(SmtpClient client, string toEmailAddress, string senderName, string receiverName, string subject, string message, bool isBodyHtml = false)
        {

            await Task.Run(() =>
            {
                SendEmailSmtp(client, toEmailAddress, senderName, receiverName, subject, message, isBodyHtml);
            });
        }

        public void SendEmailBCC(string toEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            SendEmailBCC(toEmailAddress, null, null, bCCEmailAddress, subject, message, isBodyHtml);
        }

        public void SendEmailBCC(string toEmailAddress, string senderName, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            SendEmailBCC(toEmailAddress, senderName, null, bCCEmailAddress, subject, message, isBodyHtml);
        }

        public void SendEmailBCC(string toEmailAddress, string senderName, string receiverName, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            SmtpClient client = BVSmtpClient();
            senderName = string.IsNullOrEmpty(senderName) ? SystemSenderName : senderName;
            MailMessage mailMessage = CreateMessage(toEmailAddress, senderName, receiverName, subject, message, isBodyHtml);
            if (bCCEmailAddress != null && bCCEmailAddress.Length != 0)
            {
                foreach (var address in bCCEmailAddress)
                {
                    MailAddress bcc = new MailAddress(address);
                    mailMessage.Bcc.Add(bcc);
                }
            }
            client.Send(mailMessage);
        }

        public Task SendEmailBCCAsync(string toEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailBCCAsync(string toEmailAddress, string senderName, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailBCCAsync(string toEmailAddress, string senderName, string receiverName, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            throw new NotImplementedException();
        }

        public void SendEmailCC(string toEmailAddress, string[] cCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            SendEmailCC(toEmailAddress, null, null, cCEmailAddress, subject, message, isBodyHtml);
        }

        public void SendEmailCC(string toEmailAddress, string senderName, string[] cCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            SendEmailCC(toEmailAddress, senderName, null, cCEmailAddress, subject, message, isBodyHtml);
        }

        public void SendEmailCC(string toEmailAddress, string senderName, string receiverName, string[] cCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            SmtpClient client = BVSmtpClient();
            senderName = string.IsNullOrEmpty(senderName) ? SystemSenderName : senderName;
            MailMessage mailMessage = CreateMessage(toEmailAddress, senderName, receiverName, subject, message, isBodyHtml);
            if (cCEmailAddress != null && cCEmailAddress.Length != 0)
            {
                foreach (var address in cCEmailAddress)
                {
                    MailAddress cc = new MailAddress(address);
                    mailMessage.CC.Add(cc);
                }
            }
            client.Send(mailMessage);
        }

        public Task SendEmailCCAsync(string toEmailAddress, string[] cCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailCCAsync(string toEmailAddress, string senderName, string[] cCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailCCAsync(string toEmailAddress, string senderName, string receiverName, string[] cCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            throw new NotImplementedException();
        }

        public void SendEmailCCBCC(string toEmailAddress, string[] cCEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            throw new NotImplementedException();
        }

        public void SendEmailCCBCC(string toEmailAddress, string senderName, string[] cCEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            throw new NotImplementedException();
        }

        public void SendEmailCCBCC(string toEmailAddress, string senderName, string receiverName, string[] cCEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailCCBCCAsync(string toEmailAddress, string[] cCEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailCCBCCAsync(string toEmailAddress, string senderName, string[] cCEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailCCBCCAsync(string toEmailAddress, string senderName, string receiverName, string[] cCEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false)
        {
            throw new NotImplementedException();
        }

        public void SendEmailSmtp(SmtpClient client, string toEmailAddress, string senderName, string receiverName, string subject, string message, bool isBodyHtml = false)
        {
            senderName = string.IsNullOrEmpty(senderName) ? SystemSenderName : senderName;
            MailMessage mailMessage = CreateMessage(toEmailAddress, senderName, receiverName, subject, message, isBodyHtml);
            client.Send(mailMessage);
        }

        public void SendEmailSmtpWithAttachment(SmtpClient client, string toEmailAddress, string senderName, string receiverName, string subject, string message, IFormFile attachment, bool isBodyHtml = false)
        {
            senderName = string.IsNullOrEmpty(senderName) ? SystemSenderName : senderName;
            MailMessage mailMessage = CreateMessage(toEmailAddress, senderName, receiverName, subject, message, isBodyHtml);
            if (attachment.Length > 0)
            {
                string fileName = Path.GetFileName(attachment.FileName);
                mailMessage.Attachments.Add(new Attachment(attachment.OpenReadStream(), fileName));
            }
            client.Send(mailMessage);
        }


        public void SetEmailConfig()
        {

            SmtpHost = "";
            SmtpPort = "";
            SmtpTimeout = "1000000";
            EnableSSL = false;
            SystemEmailAddress = "";
            SystemEmailPassword = "";
            SystemSenderName = "";

        }

        private SmtpClient BVSmtpClient()
        {
         //   SetEmailConfig();

            string host = SmtpHost;
            int port = int.Parse(SmtpPort);
            var smtpClient = new SmtpClient(host, port);

            bool useDefaultCredentials = EnableSSL;

            //if (!useDefaultCredentials)
            //{
            //    smtpClient.UseDefaultCredentials = false;
            //    smtpClient.Credentials = new NetworkCredential(SystemEmailAddress, SystemEmailPassword);
            //}
            //else
            //{
            //    smtpClient.UseDefaultCredentials = true;
            //}
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(SystemEmailAddress, SystemEmailPassword);

            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            int timeout;
            if (!Int32.TryParse(SmtpTimeout, out timeout))
            {
                timeout = 10;
            }
            smtpClient.Timeout = timeout * 1000;

            return smtpClient;
        }

        private MailMessage CreateMessage(string toAddress, string senderName, string receiverName, string subject, string body, bool isBodyHtml = false)
        {
            MailAddress from;
            if (string.IsNullOrEmpty(SystemEmailAddress))
            {
                SetEmailConfig();
            }
            if (!String.IsNullOrEmpty(senderName))
            {
                from = new MailAddress(SystemEmailAddress, senderName);
            }
            else
            {
                from = new MailAddress(SystemEmailAddress);
            }

            MailAddress to;
            if (!String.IsNullOrEmpty(receiverName))
            {
                to = new MailAddress(toAddress, receiverName);
            }
            else
            {
                to = new MailAddress(toAddress);
            }

            MailMessage message = new MailMessage(from, to);
            message.IsBodyHtml = isBodyHtml;
            message.Subject = subject;
            message.Body = body;

            return message;
        }
    }
}
