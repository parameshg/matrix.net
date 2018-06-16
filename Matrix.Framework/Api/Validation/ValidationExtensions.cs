using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Framework.Api.Validation
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            return services.AddScoped<ValidationFilter>();
        }
    }
}