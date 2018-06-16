using System;
using Matrix.Framework.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Framework.Api.Controllers
{
    public class ApiController : Controller
    {
        protected IResponseFactory Factory { get; }

        public ApiController(IResponseFactory factory)
        {
            Factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
    }
}