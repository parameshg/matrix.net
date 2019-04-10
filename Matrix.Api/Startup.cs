using Matrix.Api.Configuration;
using Matrix.Framework.Api.Configuration;
using Matrix.Framework.Api.Documentation;
using Matrix.Framework.ErrorHandling;
using Matrix.Framework.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Matrix.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddErrorHandler();

            var configuration = Configuration.GetSection(Settings.Root).Get<Settings>();

            services.AddServiceContext(configuration);

            if (configuration.Stub)
            {
                services.AddStubServices();
            }
            else
            {
                services.AddProxyServices();
            }

            services.AddLogging();
            services.AddRequestLogging();
            services.AddResponseFactory(Configuration);
            services.AddDocumentation(configuration.Name, configuration.Description, configuration.Version);
            services.AddMvc();

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment environment, ILoggerFactory logger)
        {
            logger.AddConsole();
            logger.AddDebug();

            app.UseExceptionHandler(i => i.UseErrorHandler());
            app.UseRequestLogging();
            app.UseDocumentation("v1");
            app.UseMvc();
        }
    }
}