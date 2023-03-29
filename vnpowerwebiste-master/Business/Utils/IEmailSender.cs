using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utils
{
    public interface IEmailSender
    {
        void SendEmail(string toEmailAddress, string subject, string message, bool isBodyHtml = false);
        void SendEmail(string toEmailAddress, string senderName, string subject, string message, bool isBodyHtml = false);
        void SendEmail(string toEmailAddress, string senderName, string receiverName, string subject, string message, bool isBodyHtml = false);

        void SendEmailCC(string toEmailAddress, string[] cCEmailAddress, string subject, string message, bool isBodyHtml = false);
        void SendEmailCC(string toEmailAddress, string senderName, string[] cCEmailAddress, string subject, string message, bool isBodyHtml = false);
        void SendEmailCC(string toEmailAddress, string senderName, string receiverName, string[] cCEmailAddress, string subject, string message, bool isBodyHtml = false);

        void SendEmailBCC(string toEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false);
        void SendEmailBCC(string toEmailAddress, string senderName, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false);
        void SendEmailBCC(string toEmailAddress, string senderName, string receiverName, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false);

        void SendEmailCCBCC(string toEmailAddress, string[] cCEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false);
        void SendEmailCCBCC(string toEmailAddress, string senderName, string[] cCEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false);
        void SendEmailCCBCC(string toEmailAddress, string senderName, string receiverName, string[] cCEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false);


        ////Async methods

        Task SendEmailAsync(string toEmailAddress, string subject, string message, bool isBodyHtml = false);
        Task SendEmailAsync(string toEmailAddress, string senderName, string subject, string message, bool isBodyHtml = false);
        Task SendEmailAsync(string toEmailAddress, string senderName, string receiverName, string subject, string message, bool isBodyHtml = false);

        Task SendEmailCCAsync(string toEmailAddress, string[] cCEmailAddress, string subject, string message, bool isBodyHtml = false);
        Task SendEmailCCAsync(string toEmailAddress, string senderName, string[] cCEmailAddress, string subject, string message, bool isBodyHtml = false);
        Task SendEmailCCAsync(string toEmailAddress, string senderName, string receiverName, string[] cCEmailAddress, string subject, string message, bool isBodyHtml = false);

        Task SendEmailBCCAsync(string toEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false);
        Task SendEmailBCCAsync(string toEmailAddress, string senderName, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false);
        Task SendEmailBCCAsync(string toEmailAddress, string senderName, string receiverName, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false);

        Task SendEmailCCBCCAsync(string toEmailAddress, string[] cCEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false);
        Task SendEmailCCBCCAsync(string toEmailAddress, string senderName, string[] cCEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false);
        Task SendEmailCCBCCAsync(string toEmailAddress, string senderName, string receiverName, string[] cCEmailAddress, string[] bCCEmailAddress, string subject, string message, bool isBodyHtml = false);

        SmtpClient LoadConfigSmtpClient();
        void SendEmailSmtp(SmtpClient client, string toEmailAddress, string senderName, string receiverName, string subject, string message, bool isBodyHtml = false);
        Task SendEmailAsyncSmtp(SmtpClient client, string toEmailAddress, string senderName, string receiverName, string subject, string message, bool isBodyHtml = false);
        void SendEmailSmtpWithAttachment(SmtpClient client, string toEmailAddress, string senderName, string receiverName, string subject, string message, IFormFile attachment, bool isBodyHtml = false);

      
    }
}
