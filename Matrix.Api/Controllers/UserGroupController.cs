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
    public class UserGroupController : Controller
    {
        public IApplicationService Registry { get; }

        public IUserGroupService Server { get; }

        public UserGroupController(IApplicationService registry, IUserGroupService server)
        {
            Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet("usergroups")]
        public async Task<IEnumerable<UserGroup>> GetUserGroups()
        {
            var result = new List<UserGroup>();

            result.AddRange(await GetUserGroups(This.Id));

            return result;
        }

        [HttpGet("applications/{application}/usergroups")]
        public async Task<IEnumerable<UserGroup>> GetUserGroups(Guid application)
        {
            var result = new List<UserGroup>();

            result.AddRange(await Server.GetUserGroups(application));

            return result;
        }
    }
}