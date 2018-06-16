using Matrix.Agent.Configurator.Configuration;
using Matrix.Agent.Configurator.Database;
using Matrix.Framework.Api.Configuration;
using Matrix.Framework.Api.Documentation;
using Matrix.Framework.Api.Errors;
using Matrix.Framework.Api.Validation;
using Matrix.Framework.Configuration;
using Matrix.Framework.Database.Configuration;
using Matrix.Framework.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Matrix.Agent.Configurator
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = Configuration.GetSection(GlobalConfiguration.Root).Get<GlobalConfiguration>();

            services.AddDatabase<ConfiguratorDbContext>(configuration);
            services.AddRepositories();
            services.AddServices();
            services.AddResponseFactory(Configuration);
            services.AddMvc();
            services.AddDocumentation(configuration.Name, configuration.Description, configuration.Version);
            services.AddExceptionHandling();
            services.AddValidation();
            services.AddLogging();
            services.AddRequestLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment environment, ILoggerFactory logger)
        {
            logger.AddConsole();
            logger.AddDebug();

            if (environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRequestLogging();
            app.UseDocumentation("v1");
            app.UseMvc();
        }
    }
}