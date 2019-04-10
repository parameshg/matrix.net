using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Framework.ErrorHandling
{
    public static class ErrorHandlingExtensions
    {
        public static IServiceCollection AddErrorHandler(this IServiceCollection services)
        {
            return services.AddTransient<ErrorHandlingMiddleware>();
        }

        public static void UseErrorHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}