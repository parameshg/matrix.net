﻿using Matrix.Agent.Postman.Business.Services;
using Matrix.Agent.Postman.Database.Repositories;
using Matrix.Framework.Business;
using Matrix.Framework.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Agent.Postman.Configuration
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryContext, RepositoryContext>();
            services.AddTransient<IHealthRepository, HealthRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<IPhoneRepository, PhoneRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IServiceContext, ServiceContext>();
            services.AddTransient<IHealthService, HealthService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IPhoneService, PhoneService>();

            return services;
        }
    }
}