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
    public class UserRoleController : Controller
    {
        public IApplicationService Registry { get; }

        public IUserRoleService Server { get; }

        public UserRoleController(IApplicationService registry, IUserRoleService server)
        {
            Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet("userroles")]
        public async Task<IEnumerable<UserRole>> GetUserRoles()
        {
            var result = new List<UserRole>();

            result.AddRange(await GetUserRoles(This.Id));

            return result;
        }

        [HttpGet("applications/{application}/userroles")]
        public async Task<IEnumerable<UserRole>> GetUserRoles(Guid application)
        {
            var result = new List<UserRole>();

            result.AddRange(await Server.GetUserRoles(application));

            return result;
        }
    }
}