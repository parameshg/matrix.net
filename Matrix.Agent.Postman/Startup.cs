using Matrix.Agent.Postman.Configuration;
using Matrix.Agent.Postman.Database;
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

namespace Matrix.Agent.Postman
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

            services.AddDatabase<PostmanDbContext>(configuration);
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
        public void Configure(IApplicationBuilder app, IApplicationLifetime lifetime, IHostingEnvironment environment, ILoggerFactory logger)
        {
            lifetime.ApplicationStarted.Register(() => Scheduler.Start());
            lifetime.ApplicationStopped.Register(() => Scheduler.Stop());

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