using System;
using System.Threading.Tasks;
using Matrix.Framework.Constants;
using Matrix.Web.Business.Services;
using Matrix.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Web.Controllers
{
    public class UserController : Controller
    {
        public IApplicationService Registry { get; }

        public IUserService Server { get; }

        public UserController(IApplicationService registry, IUserService server)
        {
            Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet]
        [Route("users")]
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
        [Route("applications/{application}/users")]
        public async Task<IActionResult> Index(Guid application)
        {
            var model = new UserListViewModel()
            {
                Application = application,
                Applications = await Registry.GetApplications(),
                Users = await Server.GetUsers(application)
            };

            return View(model);
        }
    }
}