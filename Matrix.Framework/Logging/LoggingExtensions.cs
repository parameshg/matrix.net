using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Framework.Logging
{
    public static class LoggingExtensions
    {
        public static IServiceCollection AddRequestLogging(this IServiceCollection services)
        {
            return services.AddTransient<LoggingMiddleware>();
        }

        public static void UseRequestLogging(this IApplicationBuilder app)
        {
            app.UseMiddleware<LoggingMiddleware>();
        }
    }
}