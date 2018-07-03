using System;
using System.Threading.Tasks;
using Matrix.Framework.Constants;
using Matrix.Web.Business.Services;
using Matrix.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Web.Controllers
{
    public class UserGroupController : Controller
    {
        public IApplicationService Registry { get; }

        public IUserGroupService Server { get; }

        public UserGroupController(IApplicationService registry, IUserGroupService server)
        {
            Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet]
        [Route("usergroups")]
        public async Task<IActionResult> Index()
        {
            IActionResult result = null;

            await Task.Run(() =>
            {
                result = RedirectToActionPermanent("Index", new { application = This.Id });
            });

            return result;
        }

        [HttpGet]
        [Route("applications/{application}/usergroups")]
        public async Task<IActionResult> Index(Guid application)
        {
            var model = new UserGroupListViewModel()
            {
                Application = application,
                Applications = await Registry.GetApplications(),
                UserGroups = await Server.GetUserGroups(application)
            };

            return View(model);
        }
    }
}