using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Matrix.Web.Business.Services;
using Matrix.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Web.Controllers
{
    public class HomeController : Controller
    {
        public IHealthService Health { get; set; }

        public HomeController(IHealthService health)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
        }

        public async Task<IActionResult> Index()
        {
            IActionResult result = null;

            var model = new HomeViewModel();

            model.Health.Add("Registry | Application Registry", await Health.GetRegistryHealth());
            model.Health.Add("Configurator | Configuration Repository", await Health.GetConfiguratorHealth());
            model.Health.Add("Directory | User Profiles, Roles and Groups", await Health.GetDirectoryHealth());
            model.Health.Add("Journal | Events and Logs", await Health.GetJournalHealth());
            model.Health.Add("Postman | Communication Manager", await Health.GetPostmanHealth());

            result = View(model);

            return result;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}