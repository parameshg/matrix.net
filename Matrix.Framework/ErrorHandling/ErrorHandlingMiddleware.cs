using System;
using System.Threading.Tasks;
using Matrix.Framework.Api.Response;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Matrix.Framework.ErrorHandling
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public IResponseFactory Factory { get; }

        public ErrorHandlingMiddleware(IResponseFactory factory)
        {
            Factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.StatusCode = 200;

            context.Response.ContentType = "application/json";

            var feature = context.Features.Get<IExceptionHandlerPathFeature>();

            if (feature != null)
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(Factory.GetErrorResponse(feature.Error)));
            }
            else
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(Factory.GetErrorResponse(new ApplicationException("unknown application error"))));
            }
        }
    }
}