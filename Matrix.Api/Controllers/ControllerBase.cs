using System;
using Matrix.Framework.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Api.Controllers
{
    public class ControllerBase : Controller
    {
        protected IResponseFactory Factory { get; }

        public ControllerBase(IResponseFactory factory)
        {
            Factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
    }
}