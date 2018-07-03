using System;
using System.Threading.Tasks;
using Matrix.Framework.Constants;
using Matrix.Web.Business.Services;
using Matrix.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Web.Controllers
{
    public class PhoneController : Controller
    {
        public IApplicationService Registry { get; }

        public IPhoneService Server { get; }

        public PhoneController(IApplicationService registry, IPhoneService server)
        {
            Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet]
        [Route("sms")]
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
        [Route("applications/{application}/sms")]
        public async Task<IActionResult> Index(Guid application)
        {
            var model = new PhoneListViewModel()
            {
                Application = application,
                Applications = await Registry.GetApplications(),
                Messages = await Server.GetMessages(application, DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)), DateTime.Now, 1, 10)
            };

            return View(model);
        }
    }
}