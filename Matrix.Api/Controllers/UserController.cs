using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Api.Business.Services;
using Matrix.Framework.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Api.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        public IApplicationService Registry { get; }

        public IUserService Server { get; }

        public UserController(IApplicationService registry, IUserService server)
        {
            Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet("users")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = new List<User>();

            result.AddRange(await GetUsers(This.Id));

            return result;
        }

        [HttpGet("applications/{application}/users")]
        public async Task<IEnumerable<User>> GetUsers(Guid application)
        {
            var result = new List<User>();

            result.AddRange(await Server.GetUsers(application));

            return result;
        }
    }
}