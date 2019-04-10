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
                health = new Dictionary<string, Health>()
            };

            result.health.Add("registry", await Health.GetRegistryHealth());
            result.health.Add("configurator", await Health.GetConfiguratorHealth());
            result.health.Add("directory", await Health.GetDirectoryHealth());
            result.health.Add("journal", await Health.GetJournalHealth());
            result.health.Add("postman", await Health.GetPostmanHealth());

            return result;
        }
    }
}