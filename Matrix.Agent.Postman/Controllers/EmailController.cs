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
    [Route("api/applications")]
    public class EmailController : ApiController
    {
        public IEmailService Server { get; }

        public EmailController(IResponseFactory factory, IEmailService server)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        // POST api/applications/aeb47510-69c6-4977-9646-ec13d8249917/mail
        [HttpPost("{ApplicationId}/mail")]
        public async Task<IActionResult> Post([FromRoute] Request meta, [FromBody] SendEmailRequest request)
        {
            IActionResult result = null;

            var id = await Server.SendMail(meta.Application, request.To, request.Cc, request.Bcc, request.Subject, request.Body, request.HTML);

            if (id != Guid.Empty)
                result = Factory.CreateSuccessResponse(id);
            else
                result = Factory.CreateNoContentResponse();

            return result;
        }
    }
}