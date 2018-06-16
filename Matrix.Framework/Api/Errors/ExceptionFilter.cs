using System.Threading.Tasks;
using Matrix.Framework.Api.Response;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Matrix.Framework.Api.Errors
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private ILogger<ExceptionFilter> Logger { get; }

        private IResponseFactory ResponseFactory { get; }

        public ExceptionFilter(ILogger<ExceptionFilter> logger, IResponseFactory responseFactory)
        {
            Logger = logger;

            ResponseFactory = responseFactory;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            await Task.Run(() =>
            {
                Logger.LogError(new EventId(-1, "Error"), context.Exception, $"Exception occurred while processing request {context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host}{context.HttpContext.Request.Path}");

                context.Result = ResponseFactory.CreateErrorResponse(context.Exception);
            });
        }
    }
}