using Matrix.Api.Business.Services;
using Matrix.Framework.Business;
using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Api.Configuration
{
    public static class Extensions
    {
        public static IServiceCollection AddStubServices(this IServiceCollection services)
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

            return services;
        }

        public static IServiceCollection AddProxyServices(this IServiceCollection services)
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

            return services;
        }

        public static IServiceCollection AddServiceContext(this IServiceCollection services, Settings settings)
        {
            services.AddTransient<IServiceContext>(i =>
            {
                return new ServiceContext()
                {
                    Registry = settings.Endpoints.Registry,
                    Directory = settings.Endpoints.Directory,
                    Configurator = settings.Endpoints.Configurator,
                    Journal = settings.Endpoints.Journal,
                    Postman = settings.Endpoints.Postman
                };
            });

            return services;
        }
    }
}