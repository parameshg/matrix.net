using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Api.Business.Services;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Stub
{
    public class EmailService : Service, IEmailService
    {
        public EmailService(IServiceContext context)
            : base(context)
        {
        }

        public async Task<Guid> SendMail(Guid application, List<string> to, List<string> cc, List<string> bcc, string subject, string body, bool html)
        {
            var result = Guid.Empty;

            await Task.Run(() => { result = Guid.NewGuid(); });

            return result;
        }
    }
}