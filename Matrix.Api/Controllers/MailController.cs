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
    public class MailController : ControllerBase
    {
        public IEmailService Server { get; }

        public MailController(IEmailService server, IResponseFactory factory)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpPost("applications/{Application}/mail")]
        public async Task<IActionResult> GetEmails([FromRoute] Request meta, [FromBody] SendMailRequest request)
        {
            IActionResult result = null;

            Ensure.Guid.IsNotEmpty(meta.Application);
            Ensure.Guid.IsNotEmpty(request.Application);
            Ensure.Bool.IsTrue(request.Application == meta.Application);

            var id = await Server.SendMail(meta.Application, request.To, request.Cc, request.Bcc, request.Subject, request.Body, request.HTML);

            result = Factory.CreateSuccessResponse(id);

            return result;
        }
    }
}