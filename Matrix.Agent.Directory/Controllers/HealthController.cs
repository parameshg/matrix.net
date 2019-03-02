using System;
using System.Threading.Tasks;
using Matrix.Framework.Api.Controllers;
using Matrix.Framework.Api.Response;
using Matrix.Framework.Business;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Agent.Directory.Controllers
{
    [Produces("application/json")]
    [Route("health")]
    public class HealthController : ApiController
    {
        public IHealthService Server { get; }

        public HealthController(IResponseFactory factory, IHealthService server)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        // GET /health
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IActionResult result = null;

            var test = await Server.Test();

            if (test != null)
            {
                result = Factory.CreateSuccessResponse(test);
            }
            else
            {
                result = Factory.CreateNoContentResponse();
            }

            return result;
        }
    }
}