using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Model;
using Matrix.Api.Business.Services;
using Matrix.Framework.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Api.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class MailController : Controller
    {
        public IApplicationService Registry { get; }

        public IEmailService Server { get; }

        public MailController(IApplicationService registry, IEmailService server)
        {
            Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet("emails")]
        public async Task<IEnumerable<EmailMetadata>> Index()
        {
            var result = new List<EmailMetadata>();

            result.AddRange(await GetEmails(This.Id));

            return result;
        }

        [HttpGet("applications/{application}/emails")]
        public async Task<IEnumerable<EmailMetadata>> GetEmails(Guid application)
        {
            var result = new List<EmailMetadata>();

            result.AddRange(await Server.GetEmails(application, DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)), DateTime.Now, 1, 10));

            return result;
        }
    }
}