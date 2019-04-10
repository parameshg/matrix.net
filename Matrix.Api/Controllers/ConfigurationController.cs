using System;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;
using Matrix.Api.Business.Services;
using Matrix.Api.Model;
using Matrix.Framework.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Api.Controllers
{
    [Produces("application/json")]
    public class ConfigurationController : ControllerBase
    {
        public IConfigurationService Server { get; set; }

        public ConfigurationController(IConfigurationService server, IResponseFactory factory)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet("applications/{Application}/configuration")]
        public async Task<IActionResult> GetConfiguration([FromRoute] GetConfigurationRequest request)
        {
            IActionResult result = null;

            Ensure.Guid.IsNotEmpty(request.Application);

            var model = await Server.GetSettings(request.Application);

            if (model != null)
            {
                result = Factory.CreateSuccessResponse(model);
            }
            else
            {
                result = Factory.CreateNoContentResponse();
            }

            return result;
        }

        [HttpGet("applications/{Application}/configuration/{Key}")]
        public async Task<IActionResult> GetConfiguration([FromRoute] GetConfigurationByKeyRequest request)
        {
            IActionResult result = null;

            Ensure.Guid.IsNotEmpty(request.Application);

            Ensure.String.IsNotNullOrEmpty(request.Key);

            request.Key = Encoding.ASCII.GetString(Convert.FromBase64String(request.Key));

            Ensure.String.IsNotNullOrEmpty(request.Key);

            var model = await Server.GetSettings(request.Application, request.Key);

            if (model != null)
            {
                result = Factory.CreateSuccessResponse(model);
            }
            else
            {
                result = Factory.CreateNoContentResponse();
            }

            return result;
        }
    }
}