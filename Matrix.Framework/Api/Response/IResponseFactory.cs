using System;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Framework.Api.Response
{
    public interface IResponseFactory
    {
        IActionResult CreateSuccessResponse<T>(T result);

        IActionResult CreateErrorResponse(Exception exception);

        IActionResult CreateNoContentResponse();

        IResponse GetSuccessResponse<T>(T result);

        IResponse GetErrorResponse(Exception exception);
    }
}