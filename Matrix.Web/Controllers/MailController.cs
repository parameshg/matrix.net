using System;
using System.Threading.Tasks;
using Matrix.Framework.Constants;
using Matrix.Web.Business.Services;
using Matrix.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Web.Controllers
{
    public class MailController : Controller
    {
        public IApplicationService Registry { get; }

        public IEmailService Server { get; }

        public MailController(IApplicationService registry, IEmailService server)
        {
            Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [HttpGet]
        [Route("emails")]
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
        [Route("applications/{application}/emails")]
        public async Task<IActionResult> Index(Guid application)
        {
            var model = new EmailListViewModel()
            {
                Application = application,
                Applications = await Registry.GetApplications(),
                Emails = await Server.GetEmails(application, DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)), DateTime.Now, 1, 10)
            };

            return View(model);
        }
    }
}