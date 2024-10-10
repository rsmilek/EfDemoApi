using EfDemo.Domain;
using EfDemo.Domain.Extensions;
using EfDemo.Infrastructure.SqLite.Configurations;
using EfDemo.SharedKernel.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EfDemo.Infrastructure.SqLite.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string cannot be null");
            }

            services.AddSingleton<IModelConfiguration, SqLiteModelConfiguration>();

            services.AddDbContext<EfDemoDbContext>(options =>
            {
                options.UseSqlite(connectionString, sqlOptions =>
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
