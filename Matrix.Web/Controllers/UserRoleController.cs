using System;
using System.Threading.Tasks;
using Matrix.Framework.Constants;
using Matrix.Web.Business.Services;
using Matrix.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Web.Controllers
{
    public class UserRoleController : Controller
    {
        public IApplicationService Registry { get; }

        public IUserRoleService Server { get; }

        public UserRoleController(IApplicationService registry, IUserRoleService server)
        {
            Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet]
        [Route("userroles")]
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
        [Route("applications/{application}/userroles")]
        public async Task<IActionResult> Index(Guid application)
        {
            var model = new UserRoleListViewModel()
            {
                Application = application,
                Applications = await Registry.GetApplications(),
                UserRoles = await Server.GetUserRoles(application)
            };

            return View(model);
        }
    }
}