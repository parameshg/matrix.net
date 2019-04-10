using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Framework.Api.Response
{
    public class ProductionResponseFactory : IResponseFactory
    {
        public IActionResult CreateSuccessResponse<T>(T result)
        {
            return new OkObjectResult(GetSuccessResponse<T>(result));
        }

        public IActionResult CreateNoContentResponse()
        {
            return new NoContentResult();
        }

        public IActionResult CreateErrorResponse(Exception exception)
        {
            return new BadRequestObjectResult(GetErrorResponse(exception));
        }

        public virtual IResponse GetSuccessResponse<T>(T result)
        {
            return new SuccessResponse<T>
            {
                Agent = Assembly.GetEntryAssembly().FullName,
                Status = true,
                Code = 1,
                Data = result
            };
        }

        public virtual IResponse GetErrorResponse(Exception exception)
        {
            return new ErrorResponse
            {
                Agent = Assembly.GetEntryAssembly().FullName,
                Status = false,
                Code = -1,
                Error = exception.Message
            };
        }
    }
}