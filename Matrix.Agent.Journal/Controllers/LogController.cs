using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Journal.Business.Services;
using Matrix.Agent.Journal.Model;
using Matrix.Framework.Api.Controllers;
using Matrix.Framework.Api.Model;
using Matrix.Framework.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Agent.Journal.Controllers
{
    [Produces("application/json")]
    [Route("api/applications")]
    public class LogController : ApiController
    {
        public ILogService Server { get; }

        public LogController(IResponseFactory factory, ILogService server)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        // GET api/applications/ea28f3e7-373f-43f0-973c-c87b4c3e3f3d/logs/01-01-2020T00:00:00/30-12-2020T23:59:59/1/10?q=test
        [HttpGet("{Application}/logs/{DateFrom}/{DateTo}/{Page}/{Count}")]
        public async Task<IActionResult> Get([FromRoute] GetLogRequest request, [FromQuery] string q)
        {
            IActionResult result = null;

            List<LogEntry> logs = null;

            if (string.IsNullOrEmpty(q))
                logs = await Server.Get(request.Application, request.DateFrom, request.DateTo, request.Page, request.Count);
            else
                logs = await Server.Search(request.Application, request.DateFrom, request.DateTo, q, request.Page, request.Count);

            if (logs != null)
                result = Factory.CreateSuccessResponse(logs);
            else
                result = Factory.CreateNoContentResponse();

            return result;
        }

        // POST api/applications/ea28f3e7-373f-43f0-973c-c87b4c3e3f3d/logs
        [HttpPost("{Application}/logs")]
        public async Task<IActionResult> Post([FromRoute] Request meta, [FromBody] CreateLogRequest request)
        {
            IActionResult result = null;

            var id = await Server.Save(new LogEntry()
            {
                Id = Guid.Empty,
                Timestamp = request.Timestamp,
                Application = meta.Application,
                Source = request.Source,
                Event = request.Event,
                Level = request.Level,
                Message = request.Message,
                Properties = request.Properties,
                Tags = request.Tags
            });

            result = Factory.CreateSuccessResponse(id);

            return result;
        }
    }
}