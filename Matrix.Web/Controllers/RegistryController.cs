using System;
using System.Threading.Tasks;
using Matrix.Web.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Web.Controllers
{
    public class RegistryController : Controller
    {
        public IApplicationService Server { get; }

        public RegistryController(IApplicationService server)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        public async Task<IActionResult> Index()
        {
            return View(await Server.GetApplications());
        }
    }
}