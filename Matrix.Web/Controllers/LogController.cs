using System;
using System.Threading.Tasks;
using Matrix.Framework.Constants;
using Matrix.Web.Business.Services;
using Matrix.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Web.Controllers
{
    public class LogController : Controller
    {
        public IApplicationService Registry { get; }

        public ILogService Server { get; }

        public LogController(IApplicationService registry, ILogService server)
        {
            Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet]
        [Route("logs")]
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
        [Route("applications/{application}/logs")]
        public async Task<IActionResult> Index(Guid application)
        {
            var model = new LogListViewModel()
            {
                Application = application,
                Applications = await Registry.GetApplications(),
                Logs = await Server.GetLogs(application, DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)), DateTime.Now, 1, 10)
            };

            return View(model);
        }
    }
}