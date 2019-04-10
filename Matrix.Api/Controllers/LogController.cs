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
    public class LogController : ControllerBase
    {
        public ILogService Server { get; }

        public LogController(ILogService server, IResponseFactory factory)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpPost("applications/{Application}/logs")]
        public async Task<IActionResult> Execute([FromRoute] Request meta, [FromBody] LogRequest request)
        {
            IActionResult result = null;

            Ensure.Guid.IsNotEmpty(meta.Application);
            Ensure.Guid.IsNotEmpty(request.Application);
            Ensure.Bool.IsTrue(request.Application == meta.Application);

            await Server.SaveLogEntry(meta.Application, request.Message, request.Timestamp, request.Source, request.Level, request.Event, request.Properties, request.Tags);

            result = Factory.CreateSuccessResponse(true);

            return result;
        }
    }
}