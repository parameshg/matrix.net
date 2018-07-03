using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Model;
using Matrix.Framework.Business;
using Matrix.Web.Business.Services;

namespace Matrix.Web.Business.Stub
{
    public class EmailService : Service, IEmailService
    {
        public EmailService(IServiceContext context)
            : base(context)
        {
        }

        public async Task<List<EmailMetadata>> GetEmails(Guid application, DateTime from, DateTime to, int page = 1, int count = 10)
        {
            var result = new List<EmailMetadata>();

            await Task.Run(() => { });

            return result;
        }

        public async Task<List<EmailMetadata>> Search(Guid application, DateTime from, DateTime to, string pattern, int page = 1, int count = 10)
        {
            var result = new List<EmailMetadata>();

            await Task.Run(() => { });

            return result;
        }

        public async Task<Guid> SendMail(Guid application, List<string> to, List<string> cc, List<string> bcc, string subject, string body, bool html)
        {
            var result = Guid.Empty;

            await Task.Run(() => { result = Guid.NewGuid(); });

            return result;
        }
    }
}