using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Matrix.Framework.Logging
{
    public class LoggingMiddleware : IMiddleware
    {
        private ILogger<LoggingMiddleware> Logger { get; }

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
        {
            Logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var sb = new StringBuilder();

            sb.Append($"Request: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path} | ");

            try
            {
                await next(context);

                sb.Append($"Response: {context.Response.StatusCode}");

                Logger.LogInformation(sb.ToString());
            }
            catch (Exception e)
            {
                sb.Append($"Exception: {e.Message}");

                Logger.LogError(sb.ToString());

                throw;
            }
        }
    }
}