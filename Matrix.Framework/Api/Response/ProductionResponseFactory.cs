using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Framework.Api.Response
{
    public class ProductionResponseFactory : IResponseFactory
    {
        public IActionResult CreateSuccessResponse(object result)
        {
            return new OkObjectResult(GetSuccessResponse(result));
        }

        public IActionResult CreateNoContentResponse()
        {
            return new NoContentResult();
        }

        public IActionResult CreateErrorResponse(Exception exception)
        {
            return new BadRequestObjectResult(GetErrorResponse(exception));
        }

        protected virtual SuccessResponse GetSuccessResponse(object result)
        {
            return new SuccessResponse
            {
                Agent = Assembly.GetEntryAssembly().FullName,
                Status = true,
                Code = 1,
                Data = result
            };
        }

        protected virtual ErrorResponse GetErrorResponse(Exception exception)
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