using Matrix.Api.Business.Services;
using Matrix.Api.Configuration;
using Matrix.Framework.Api.Documentation;
using Matrix.Framework.Business;
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
            var configuration = Configuration.GetSection(Settings.Root).Get<Settings>();

            services.AddTransient<IServiceContext>(i =>
            {
                return new ServiceContext()
                {
                    Registry = configuration.Endpoints.Registry,
                    Directory = configuration.Endpoints.Directory,
                    Configurator = configuration.Endpoints.Configurator,
                    Journal = configuration.Endpoints.Journal,
                    Postman = configuration.Endpoints.Postman,
                };
            });

            if (configuration.Stub)
            {
                services.AddSingleton<Business.Services.IHealthService, Business.Stub.HealthService>();
                services.AddSingleton<IApplicationService, Business.Stub.ApplicationService>();
                services.AddSingleton<IConfigurationService, Business.Stub.ConfigurationService>();
                services.AddSingleton<ILogService, Business.Stub.LogService>();
                services.AddSingleton<IUserService, Business.Stub.UserService>();
                services.AddSingleton<IUserGroupService, Business.Stub.UserGroupService>();
                services.AddSingleton<IUserRoleService, Business.Stub.UserRoleService>();
                services.AddSingleton<IEmailService, Business.Stub.EmailService>();
                services.AddSingleton<IPhoneService, Business.Stub.PhoneService>();
            }
            else
            {
                services.AddTransient<Business.Services.IHealthService, Business.Proxy.HealthService>();
                services.AddTransient<IApplicationService, Business.Proxy.ApplicationService>();
                services.AddTransient<IConfigurationService, Business.Proxy.ConfigurationService>();
                services.AddTransient<ILogService, Business.Proxy.LogService>();
                services.AddTransient<IUserService, Business.Proxy.UserService>();
                services.AddTransient<IUserGroupService, Business.Proxy.UserGroupService>();
                services.AddTransient<IUserRoleService, Business.Proxy.UserRoleService>();
                services.AddTransient<IEmailService, Business.Proxy.EmailService>();
                services.AddTransient<IPhoneService, Business.Proxy.PhoneService>();
            }

            services.AddLogging();
            services.AddRequestLogging();
            services.AddDocumentation(configuration.Name, configuration.Description, configuration.Version);
            services.AddMvc();
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            logger.AddConsole();
            logger.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestLogging();
            app.UseDocumentation("v1");
            app.UseMvc();
        }
    }
}