using Microsoft.Extensions.DependencyInjection;

namespace EfDemo.Domain.Extensions
{
    public static class DomainServiceRegistration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            ////services.AddScoped<PromotionService>();
            return services;
        }
    }
}
