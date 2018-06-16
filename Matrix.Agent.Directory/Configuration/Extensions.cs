using Matrix.Agent.Directory.Business.Services;
using Matrix.Agent.Directory.Database.Repositories;
using Matrix.Framework.Business;
using Matrix.Framework.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Agent.Directory.Configuration
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryContext, RepositoryContext>();
            services.AddTransient<IHealthRepository, HealthRepository>();
            services.AddTransient<IUserGroupRepository, UserGroupRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IServiceContext, ServiceContext>();
            services.AddTransient<IHealthService, HealthService>();
            services.AddTransient<IUserGroupService, UserGroupService>();
            services.AddTransient<IUserRoleService, UserRoleService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}