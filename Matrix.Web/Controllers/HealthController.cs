using System;
using Matrix.Web.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Web.Controllers
{
    public class HealthController : Controller
    {
        public IHealthService Server { get; }

        public HealthController(IHealthService server)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}