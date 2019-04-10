using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Business.Services;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Api.Controllers;
using Matrix.Framework.Api.Model;
using Matrix.Framework.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Agent.Directory.Controllers
{
    [Produces("application/json")]
    [Route("applications")]
    public class UserController : ApiController
    {
        public IUserService Server { get; }

        public UserController(IResponseFactory factory, IUserService server)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet("{Application}/users")]
        public async Task<IActionResult> Get([FromRoute] GetUsersRequest request)
        {
            IActionResult result = null;

            List<User> users = await Server.GetUsers(request.Application);

            if (users != null)
            {
                result = Factory.CreateSuccessResponse(users);
            }
            else
            {
                result = Factory.CreateNoContentResponse();
            }

            return result;
        }

        [HttpGet("{Application}/users/{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetUserByIdRequest request)
        {
            IActionResult result = null;

            var user = await Server.GetUserById(request.Id);

            if (user != null)
            {
                result = Factory.CreateSuccessResponse(user);
            }
            else
            {
                result = Factory.CreateNoContentResponse();
            }

            return result;
        }

        [HttpPost("{Application}/users")]
        public async Task<IActionResult> Post([FromRoute] Request meta, [FromBody] CreateUserRequest request)
        {
            IActionResult result = null;

            var id = await Server.CreateUser(meta.Application, request.FirstName, request.LastName, request.Username, request.Password, request.Email, request.Phone);

            if (id != Guid.Empty)
            {
                result = Factory.CreateSuccessResponse(id);
            }
            else
            {
                result = Factory.CreateNoContentResponse();
            }

            return result;
        }

        [HttpPut("{Application}/users")]
        public async Task<IActionResult> Put([FromRoute] Request meta, [FromBody] UpdateUserRequest request)
        {
            IActionResult result = null;

            var updated = await Server.UpdateUserProfile(request.Id, request.FirstName, request.LastName, request.Email, request.Phone);

            if (updated)
            {
                result = Factory.CreateSuccessResponse(updated);
            }
            else
            {
                result = Factory.CreateNoContentResponse();
            }

            return result;
        }

        [HttpDelete("{Application}/users/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserRequest request)
        {
            IActionResult result = null;

            var deleted = await Server.DeleteUser(request.Id);

            if (deleted)
            {
                result = Factory.CreateSuccessResponse(deleted);
            }
            else
            {
                result = Factory.CreateNoContentResponse();
            }

            return result;
        }
    }
}