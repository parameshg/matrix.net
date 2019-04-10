using System;
using System.Threading.Tasks;
using EnsureThat;
using Matrix.Api.Business.Services;
using Matrix.Api.Model;
using Matrix.Framework.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Api.Controllers
{
    [Produces("application/json")]
    public class ApplicationController : ControllerBase
    {
        public IApplicationService Server { get; set; }

        public ApplicationController(IApplicationService server, IResponseFactory factory)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet("applications")]
        public async Task<IActionResult> Get()
        {
            IActionResult result = null;

            var applications = await Server.GetApplications();

            if (applications != null)
            {
                result = Factory.CreateSuccessResponse(applications);
            }
            else
            {
                result = Factory.CreateNoContentResponse();
            }

            return result;
        }

        [HttpGet("applications/{Application}/login")]
        public async Task<IActionResult> Login([FromRoute] LoginRequest request)
        {
            IActionResult result = null;

            Ensure.Guid.IsNotEmpty(request.Application);

            result = Factory.CreateSuccessResponse(await Server.Login(request.Application));

            return result;
        }

        [HttpGet("applications/{Application}/logout")]
        public async Task<IActionResult> Logout([FromRoute] LogoutRequest request)
        {
            IActionResult result = null;

            Ensure.Guid.IsNotEmpty(request.Application);

            result = Factory.CreateSuccessResponse(await Server.Logout(request.Application));

            return result;
        }
    }
}