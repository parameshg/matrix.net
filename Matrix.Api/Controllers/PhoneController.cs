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
    public class PhoneController : Controller
    {
        public IApplicationService Registry { get; }

        public IPhoneService Server { get; }

        public PhoneController(IApplicationService registry, IPhoneService server)
        {
            Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet("sms")]
        public async Task<IEnumerable<PhoneMessageMetadata>> GetMessages()
        {
            var result = new List<PhoneMessageMetadata>();

            result.AddRange(await GetMessages(This.Id));

            return result;
        }

        [HttpGet("applications/{application}/sms")]
        public async Task<IEnumerable<PhoneMessageMetadata>> GetMessages(Guid application)
        {
            var result = new List<PhoneMessageMetadata>();

            result.AddRange(await Server.GetMessages(application, DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)), DateTime.Now, 1, 10));

            return result;
        }
    }
}