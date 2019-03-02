using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Registry.Business.Services;
using Matrix.Agent.Registry.Model;
using Matrix.Framework.Api.Controllers;
using Matrix.Framework.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Agent.Registry.Controllers
{
    [Produces("application/json")]
    [Route("applications")]
    public class ApplicationController : ApiController
    {
        public IApplicationService Server { get; }

        public ApplicationController(IResponseFactory factory, IApplicationService server)
            : base(factory)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        // GET /applications
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            IActionResult result = null;

            List<Application> applications = await Server.Get();

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

        // POST /applications
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateApplicationRequest request)
        {
            IActionResult result = null;

            var id = await Server.Register(request.Name, request.Description);

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

        // PUT /applications
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateApplicationRequest request)
        {
            IActionResult result = null;

            var updated = await Server.Update(request.Id, request.Name, request.Description);

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

        // DELETE /applications/130adae6-1a60-49e4-aca4-c8a2b90dcbd5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteApplicationRequest request)
        {
            IActionResult result = null;

            var deleted = await Server.Delete(request.Id);

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