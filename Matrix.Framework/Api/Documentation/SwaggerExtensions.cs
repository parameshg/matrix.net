using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Matrix.Framework.Api.Documentation
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddDocumentation(this IServiceCollection services, string name, string description, string version)
        {
            services.AddSwaggerGen(i =>
            {
                i.SwaggerDoc(version, new Info()
                {
                    Title = name,
                    Description = description,
                    Version = version,
                    Contact = new Contact()
                    {
                        Name = "Paramesh Gunasekaran",
                        Email = "paramesh.gunasekaran@gmail.com",
                        Url = "https://www.paramg.com"
                    },
                    License = new License()
                    {
                        Name = "The MIT License",
                        Url = "https://opensource.org/licenses/MIT"
                    },
                    TermsOfService = "https://opensource.org/ToS"
                });
            });

            return services;
        }

        public static IApplicationBuilder UseDocumentation(this IApplicationBuilder app, string version)
        {
            app.UseSwagger();

            app.UseSwaggerUI(i =>
            {
                i.SwaggerEndpoint($"/swagger/{version}/swagger.json", version);
            });

            return app;
        }
    }
}