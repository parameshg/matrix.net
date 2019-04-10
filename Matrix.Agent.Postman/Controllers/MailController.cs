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
    public class MailController : ApiController
    {
        public IMailService Server { get; }

        public MailController(IResponseFactory factory, IMailService server)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpPost("applications/{Application}/mail")]
        public async Task<IActionResult> Post([FromRoute] Request meta, [FromBody] SendEmailRequest request)
        {
            IActionResult result = null;

            var id = await Server.SendMail(request.Application, request.To, request.Cc, request.Bcc, request.Subject, request.Body, request.HTML);

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