using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Api.Business.Services;
using Matrix.Framework;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Api.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class HealthController : Controller
    {
        public IHealthService Health { get; set; }

        public HealthController(IHealthService health)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
        }

        [HttpGet("health")]
        public async Task<Dictionary<string, Health>> Get()
        {
            var result = new Dictionary<string, Health>();

            result.Add("registry", await Health.GetRegistryHealth());
            result.Add("configurator", await Health.GetConfiguratorHealth());
            result.Add("directory", await Health.GetDirectoryHealth());
            result.Add("journal", await Health.GetJournalHealth());
            result.Add("postman", await Health.GetPostmanHealth());

            return result;
        }
    }
}