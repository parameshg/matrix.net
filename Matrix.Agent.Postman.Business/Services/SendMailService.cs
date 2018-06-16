using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Matrix.Framework.Business;
using Polly;

namespace Matrix.Agent.Postman.Business.Services
{
    public class SendMailService : Service, ISendMailService
    {
        public SendMailService(IServiceContext context)
            : base(context)
        {
        }

        public async Task<bool> Execute(string host, int port, string username, string password, string from, List<string> to, List<string> cc, List<string> bcc, string subject, string body, bool html)
        {
            var result = false;

            await Policy.Handle<Exception>().WaitAndRetryAsync(3, i => new TimeSpan(0, 0, i * 10)).ExecuteAsync(async () =>
            {
                try
                {
                    using (var mail = new MailMessage())
                    {
                        mail.From = new MailAddress(from);
                        to.ForEach(i => mail.To.Add(i));
                        cc.ForEach(i => mail.CC.Add(i));
                        bcc.ForEach(i => mail.Bcc.Add(i));
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = html;

                        using (var client = new SmtpClient())
                        {
                            client.Host = host;
                            client.Port = port;
                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            client.Credentials = new NetworkCredential(username, password);
                            await client.SendMailAsync(mail);
                        }
                    }

                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            });

            return result;
        }
    }
}