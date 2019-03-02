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
    public class UserGroupController : ApiController
    {
        public IUserGroupService Server { get; }

        public UserGroupController(IResponseFactory factory, IUserGroupService server)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        // GET /applications/130adae6-1a60-49e4-aca4-c8a2b90dcbd5/usergroups
        [HttpGet("{Application}/usergroups")]
        public async Task<IActionResult> Get([FromRoute] GetUserGroupsRequest request)
        {
            IActionResult result = null;

            List<UserGroup> applications = await Server.GetUserGroups(request.Application);

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

        // POST /applications/130adae6-1a60-49e4-aca4-c8a2b90dcbd5/
        [HttpPost("{Application}/usergroups")]
        public async Task<IActionResult> Post([FromRoute] Request route, [FromBody] CreateUserGroupRequest request)
        {
            IActionResult result = null;

            var id = await Server.CreateUserGroup(route.Application, request.Name, request.Description);

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

        // PUT /applications/130adae6-1a60-49e4-aca4-c8a2b90dcbd5/usergroups
        [HttpPut("{Application}/usergroups")]
        public async Task<IActionResult> Put([FromRoute] Request route, [FromBody] UpdateUserGroupRequest request)
        {
            IActionResult result = null;

            var updated = await Server.UpdateUserGroup(request.Id, request.Name, request.Description);

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

        // DELETE /applications/130adae6-1a60-49e4-aca4-c8a2b90dcbd5/usergroups/b08a9b18-c1a8-4ee5-923e-e720eaf748df
        [HttpDelete("{Application}/usergroups/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserGroupRequest request)
        {
            IActionResult result = null;

            var deleted = await Server.DeleteUserGroup(request.Id);

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