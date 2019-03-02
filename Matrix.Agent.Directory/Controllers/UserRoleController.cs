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
    public class UserRoleController : ApiController
    {
        public IUserRoleService Server { get; }

        public UserRoleController(IResponseFactory factory, IUserRoleService server)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        // GET /applications/130adae6-1a60-49e4-aca4-c8a2b90dcbd5/userroles
        [HttpGet("{Application}/userroles")]
        public async Task<IActionResult> Get([FromRoute] GetUserRolesRequest request)
        {
            IActionResult result = null;

            List<UserRole> applications = await Server.GetUserRoles(request.Application);

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

        // POST /applications/130adae6-1a60-49e4-aca4-c8a2b90dcbd5/userroles
        [HttpPost("{Application}/userroles")]
        public async Task<IActionResult> Post([FromRoute] Request meta, [FromBody] CreateUserRoleRequest request)
        {
            IActionResult result = null;

            var id = await Server.CreateUserRole(meta.Application, request.Name, request.Description);

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

        // PUT /applications/130adae6-1a60-49e4-aca4-c8a2b90dcbd5/userroles
        [HttpPut("{Application}/userroles")]
        public async Task<IActionResult> Put([FromRoute] Request meta, [FromBody] UpdateUserRoleRequest request)
        {
            IActionResult result = null;

            var updated = await Server.UpdateUserRole(request.Id, request.Name, request.Description);

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

        // DELETE /applications/130adae6-1a60-49e4-aca4-c8a2b90dcbd5/userroles/b08a9b18-c1a8-4ee5-923e-e720eaf748df
        [HttpDelete("{Application}/userroles/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserRoleRequest request)
        {
            IActionResult result = null;

            var deleted = await Server.DeleteUserRole(request.Id);

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