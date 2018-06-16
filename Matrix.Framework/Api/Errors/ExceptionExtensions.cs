using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Framework.Api.Errors
{
    public static class ExceptionExtensions
    {
        public static IServiceCollection AddExceptionHandling(this IServiceCollection services)
        {
            return services.AddScoped<ExceptionFilter>();
        }
    }
}