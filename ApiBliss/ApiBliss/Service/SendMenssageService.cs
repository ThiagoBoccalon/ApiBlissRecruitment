
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ApiBliss.Service
{
    public class SendMenssageService : ISendMessageService
    {
        private const string EMAIL_FROM = "apiblissrecruitment@yahoo.com";
        private const string EMAIL_PASSWORD = "22@TestApi";
        private const string SUBJECT = "TEST API BLISS RECRUITMENT";

        private readonly IConfiguration _config;

        public SendMenssageService(IConfiguration config)
        {
            _config = config;
        }

        public Task SendEmailAsync(string emailTo, string body)
        {
            try
            {
                Execute(emailTo, body).Wait();
                return Task.FromResult(0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Execute(string emailTo, string body)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(EMAIL_FROM, "API Bliss Recruitment")
                };

                mail.To.Add(new MailAddress(emailTo));                
                mail.Subject = SUBJECT;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (var client = new SmtpClient("smtp.mail.yahoo.com", 587))
                {   
                    client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    client.PickupDirectoryLocation = @"D:\";
                    client.Send(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
