using EfDemo.Domain;
using EfDemo.Infrastructure.SqLite.Configurations;
using EfDemo.SharedKernel.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EfDemo.Infrastructure.SqLite.Extensions
{
    public static class SqlLiteServiceRegistration
    {
        public static IServiceCollection AddSqLiteInfrastructure(this IServiceCollection services, string? connectionString)
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
                    sqlOptions.MigrationsAssembly(typeof(SqlLiteServiceRegistration).Assembly.FullName);
                })
                ////.EnableSensitiveDataLogging() // TODO: Remove this line in production
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;
        }
    }
}
