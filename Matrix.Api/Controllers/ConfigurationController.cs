using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Api.Business.Services;
using Matrix.Framework.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Api.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class ConfigurationController : Controller
    {
        public IConfigurationService Server { get; set; }

        public ConfigurationController(IConfigurationService server)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet("configuration")]
        public async Task<IEnumerable<KeyValuePair<string, string>>> GetConfiguration()
        {
            var result = new List<KeyValuePair<string, string>>();

            result.AddRange(await GetConfiguration(This.Id));

            return result;
        }


        [HttpGet("applications/{application}/configuration")]
        public async Task<IEnumerable<KeyValuePair<string, string>>> GetConfiguration(Guid application)
        {
            var result = new List<KeyValuePair<string, string>>();

            result.AddRange(await Server.GetSettings(application));

            return result;
        }
    }
}