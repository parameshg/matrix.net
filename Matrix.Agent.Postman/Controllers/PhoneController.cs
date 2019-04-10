using System;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Business.Services;
using Matrix.Agent.Postman.Model;
using Matrix.Framework.Api.Controllers;
using Matrix.Framework.Api.Model;
using Matrix.Framework.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Agent.Postman.Controllers
{
    [Produces("application/json")]
    [Route("applications")]
    public class PhoneController : ApiController
    {
        public IPhoneService Server { get; }

        public PhoneController(IResponseFactory factory, IPhoneService server)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpPost("{ApplicationId}/sms")]
        public async Task<IActionResult> Post([FromRoute] Request meta, [FromBody] SendSmsRequest request)
        {
            IActionResult result = null;

            var id = await Server.SendMessage(meta.Application, request.To, request.Message);

            if (id != Guid.Empty)
            {
                result = Factory.CreateSuccessResponse(id);
            }
            else
            {
                result = Factory.CreateNoContentResponse();
            }

            return result;
        }
    }
}