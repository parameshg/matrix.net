using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
            var timer = new Stopwatch();

            timer.Start();

            await next(context);

            timer.Stop();

            Logger.LogInformation(JsonConvert.SerializeObject(new
            {
                request = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}",
                response = context.Response.StatusCode,
                duration = timer.ElapsedMilliseconds
            }));
        }
    }
}