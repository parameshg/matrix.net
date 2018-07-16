using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Journal.Model;
using Matrix.Api.Business.Services;
using Matrix.Framework.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Api.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class LogController : Controller
    {
        public IApplicationService Registry { get; }

        public ILogService Server { get; }

        public LogController(IApplicationService registry, ILogService server)
        {
            Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet]
        [Route("logs")]
        public async Task<IEnumerable<LogEntry>> GetLogs()
        {
            var result = new List<LogEntry>();

            result.AddRange(await GetLogs(This.Id));

            return result;
        }

        [HttpGet]
        [Route("applications/{application}/logs")]
        public async Task<IEnumerable<LogEntry>> GetLogs(Guid application)
        {
            var result = new List<LogEntry>();

            result.AddRange(await Server.GetLogs(application, DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)), DateTime.Now, 1, 10));

            return result;
        }
    }
}