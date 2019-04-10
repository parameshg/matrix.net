using System;
using System.Threading.Tasks;
using EnsureThat;
using Matrix.Api.Business.Services;
using Matrix.Api.Model;
using Matrix.Framework.Api.Model;
using Matrix.Framework.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Api.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class PhoneController : ControllerBase
    {
        public IApplicationService Registry { get; }

        public IPhoneService Server { get; }

        public PhoneController(IPhoneService server, IResponseFactory factory)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpPost("applications/{Application}/text")]
        public async Task<IActionResult> SendMessage([FromRoute] Request meta, [FromBody] SendTextRequest request)
        {
            IActionResult result = null;

            Ensure.Guid.IsNotEmpty(meta.Application);
            Ensure.Guid.IsNotEmpty(request.Application);
            Ensure.Bool.IsTrue(request.Application == meta.Application);

            var id = await Server.SendText(meta.Application, request.To, request.Message);

            result = Factory.CreateSuccessResponse(id);

            return result;
        }
    }
}