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
    public class UserGroupController : ControllerBase
    {
        public IUserGroupService Server { get; }

        public UserGroupController(IUserGroupService server, IResponseFactory factory)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet("applications/{application}/usergroups")]
        public async Task<IActionResult> GetUserGroups(Guid application)
        {
            IActionResult result = null;

            Ensure.Guid.IsNotEmpty(application);

            var users = await Server.GetUserGroups(application);

            Ensure.Any.IsNotNull(users);

            result = Factory.CreateSuccessResponse(users);

            return result;
        }
    }
}