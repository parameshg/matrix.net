using Matrix.Framework.Business;
using Matrix.Web.Business.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Web
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
            services.AddTransient<IServiceContext, ServiceContext>();

            if (bool.Parse(Configuration["Stub"]))
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

            services.AddMvc();
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}