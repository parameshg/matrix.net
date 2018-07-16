using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Api.Business.Services;
using Matrix.Framework;
using Matrix.Framework.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Api.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class HomeController : Controller
    {
        public IHealthService Health { get; set; }

        public HomeController(IHealthService health)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
        }

        [HttpGet]
        public async Task<dynamic> Get()
        {
            dynamic result = new
            {
                id = This.Id,
                name = This.Name,
                description = This.Description,
                health = new List<Health>()
            };

            result.health.Add(await Health.GetRegistryHealth());
            result.health.Add(await Health.GetConfiguratorHealth());
            result.health.Add(await Health.GetDirectoryHealth());
            result.health.Add(await Health.GetJournalHealth());
            result.health.Add(await Health.GetPostmanHealth());

            return result;
        }
    }
}