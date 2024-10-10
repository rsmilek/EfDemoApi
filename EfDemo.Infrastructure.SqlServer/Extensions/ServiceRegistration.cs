﻿using EfDemo.Domain;
using EfDemo.Domain.Extensions;
using EfDemo.Infrastructure.Configurations;
using EfDemo.SharedKernel.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EfDemo.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string cannot be null");
            }

            services.AddSingleton<IModelConfiguration, SqlModelConfiguration>();

            services.AddDbContext<EfDemoDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(ServiceRegistration).Assembly.FullName);
                })
                ////.EnableSensitiveDataLogging() // TODO: Remove this line in production
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            });
            
            services.AddDomain();

            return services;
        }
    }
}