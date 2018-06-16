using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Configurator.Business.Services;
using Matrix.Agent.Configurator.Controllers.Model;
using Matrix.Framework.Api.Controllers;
using Matrix.Framework.Api.Model;
using Matrix.Framework.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Agent.Configurator.Controllers
{
    [Produces("application/json")]
    [Route("api/applications")]
    public class ConfigurationController : ApiController
    {
        public IConfigurationService Server { get; }

        public ConfigurationController(IResponseFactory factory, IConfigurationService server)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        // GET api/applications/e9d80d86-59e4-407e-b7d8-65535da6f745/configuration
        [HttpGet("{Application}/configuration")]
        public async Task<IActionResult> Get([FromRoute] GetConfigurationByApplicationRequest request)
        {
            IActionResult result = null;

            List<KeyValuePair<string, string>> settings = await Server.GetSettings(request.Application);

            if (settings != null)
                result = Factory.CreateSuccessResponse(settings);
            else
                result = Factory.CreateNoContentResponse();

            return result;
        }

        // GET api/applications/e9d80d86-59e4-407e-b7d8-65535da6f745/configuration/mail.host
        [HttpGet("{Application}/configuration/{Key}")]
        public async Task<IActionResult> Get([FromRoute] GetConfigurationByKeyRequest request)
        {
            IActionResult result = null;

            var settings = await Server.GetSettings(request.Application, request.Key);

            if (settings != null)
                result = Factory.CreateSuccessResponse(settings);
            else
                result = Factory.CreateNoContentResponse();

            return result;
        }

        // POST api/applications/e9d80d86-59e4-407e-b7d8-65535da6f745/configuration
        [HttpPost("{Application}/configuration")]
        public async Task<IActionResult> Post([FromRoute] Request meta, [FromBody] CreateConfigurationRequest request)
        {
            IActionResult result = null;

            var id = await Server.Create(meta.Application, request.Key, request.Value);

            if (id != Guid.Empty)
                result = Factory.CreateSuccessResponse(id);
            else
                result = Factory.CreateNoContentResponse();

            return result;
        }

        // PUT api/applications/e9d80d86-59e4-407e-b7d8-65535da6f745/configuration
        [HttpPut("{Application}/configuration")]
        public async Task<IActionResult> Put([FromRoute] Request meta, [FromBody] UpdateConfigurationRequest request)
        {
            IActionResult result = null;

            var updated = await Server.Update(meta.Application, request.Key, request.Value);

            if (updated)
                result = Factory.CreateSuccessResponse(updated);
            else
                result = Factory.CreateNoContentResponse();

            return result;
        }

        // DELETE api/applications/130adae6-1a60-49e4-aca4-c8a2b90dcbd5/configuration/mail.host
        [HttpDelete("{Application}/configuration/{Key}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteConfigurationRequest request)
        {
            IActionResult result = null;

            var deleted = await Server.Delete(request.Application, request.Key);

            if (deleted)
                result = Factory.CreateSuccessResponse(deleted);
            else
                result = Factory.CreateNoContentResponse();

            return result;
        }
    }
}