using EfDemo.Domain.Abstractions;
using EfDemo.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EfDemo.Domain.Extensions
{
    public static class DomainServiceRegistration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICoverService, CoverService>();
            
            return services;
        }
    }
}
