﻿using System.Net;
using System.Net.Mail;
using TestProject.IServices;

namespace TestProject.Services
{
    public class MailService : IMailService
    {

        public object SendEmail(string to, string subject, string body)
        {
            //smtp client settings
            var smtpClient = new SmtpClient("smtp.yandex.com", 587);
           
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential(
                "your_mail_address", "your mail password"
            );
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 5000;

            try
            {
                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("your_mail_address" ,"User Token Service");

                mailMessage.Subject = subject;
                mailMessage.Body = body;
                //mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(to);

                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                string result = ex.Message;
                return new ArgumentNullException(result);
            }
        }
    }
}
