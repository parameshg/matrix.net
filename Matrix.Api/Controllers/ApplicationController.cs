using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Registry.Model;
using Matrix.Api.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Api.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class ApplicationController : Controller
    {
        public IApplicationService Server { get; set; }

        public ApplicationController(IApplicationService server)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet("applications")]
        public async Task<IEnumerable<Application>> Get()
        {
            var result = new List<Application>();

            result.AddRange(await Server.GetApplications());

            return result;
        }
    }
}