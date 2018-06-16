using System;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Framework.Api.Response
{
    public interface IResponseFactory
    {
        IActionResult CreateSuccessResponse(object result);

        IActionResult CreateErrorResponse(Exception exception);

        IActionResult CreateNoContentResponse();
    }
}