using System;
using System.Threading.Tasks;
using Matrix.Framework.Constants;
using Matrix.Web.Business.Services;
using Matrix.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Web.Controllers
{
    [Route("")]
    public class ConfigurationController : Controller
    {
        public IApplicationService Registry { get; }

        public IConfigurationService Server { get; }

        public ConfigurationController(IApplicationService registry, IConfigurationService server)
        {
            Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet]
        [Route("configuration")]
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
        [Route("applications/{application}/configuration")]
        public async Task<IActionResult> Index(Guid application)
        {
            var model = new ConfigurationListViewModel()
            {
                Application = application,
                Applications = await Registry.GetApplications(),
                Settings = await Server.GetSettings(application)
            };

            return View(model);
        }
    }
}