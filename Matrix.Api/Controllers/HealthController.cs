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
        public async Task<IEnumerable<Health>> Get()
        {
            var result = new List<Health>();

            result.Add(await Health.GetRegistryHealth());
            result.Add(await Health.GetConfiguratorHealth());
            result.Add(await Health.GetDirectoryHealth());
            result.Add(await Health.GetJournalHealth());
            result.Add(await Health.GetPostmanHealth());

            return result;
        }
    }
}