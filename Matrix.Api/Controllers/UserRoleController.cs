using System;
using System.Threading.Tasks;
using EnsureThat;
using Matrix.Api.Business.Services;
using Matrix.Framework.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Api.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class UserRoleController : ControllerBase
    {
        public IUserRoleService Server { get; }

        public UserRoleController(IUserRoleService server, IResponseFactory factory)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet("applications/{application}/userroles")]
        public async Task<IActionResult> GetUserRoles(Guid application)
        {
            IActionResult result = null;

            Ensure.Guid.IsNotEmpty(application);

            var users = await Server.GetUserRoles(application);

            Ensure.Any.IsNotNull(users);

            result = Factory.CreateSuccessResponse(users);

            return result;
        }
    }
}