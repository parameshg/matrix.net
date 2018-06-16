using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public class EmailService : Service, IEmailService
    {
        public EmailService(IServiceContext context)
            : base(context)
        {
        }

        public Task<Guid> SendMail(Guid application, List<string> to, List<string> cc, List<string> bcc, string subject, string body, bool html)
        {
            throw new NotImplementedException();
        }
    }
}