using EfDemo.Infrastructure.SqlServer.Extensions;
using EfDemo.Infrastructure.SqLite.Extensions;

namespace EfDemo.Api.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string cannot be null");
            }

            if (connectionString.Contains("Server"))
            {
                return services.AddSqlServerInfrastructure(connectionString);
            }
            else
            {
                return services.AddSqLiteInfrastructure(connectionString);
            }
        }
    }
}
