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
    public class UserController : ControllerBase
    {
        public IUserService Server { get; }

        public UserController(IUserService server, IResponseFactory factory)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet("applications/{application}/users")]
        public async Task<IActionResult> GetUsers(Guid application)
        {
            IActionResult result = null;

            Ensure.Guid.IsNotEmpty(application);

            var users = await Server.GetUsers(application);

            Ensure.Any.IsNotNull(users);

            result = Factory.CreateSuccessResponse(users);

            return result;
        }

        [HttpGet("applications/{application}/users/{id}")]
        public async Task<IActionResult> GetUserById(Guid application, Guid id)
        {
            IActionResult result = null;

            Ensure.Guid.IsNotEmpty(application);

            Ensure.Guid.IsNotEmpty(id);

            var user = await Server.GetUserById(application, id);

            Ensure.Any.IsNotNull(user);

            result = Factory.CreateSuccessResponse(user);

            return result;
        }
    }
}