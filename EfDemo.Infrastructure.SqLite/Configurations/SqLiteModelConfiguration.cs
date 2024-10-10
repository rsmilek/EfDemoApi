using EfDemo.SharedKernel.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EfDemo.Infrastructure.SqLite.Configurations
{
    public class SqLiteModelConfiguration : IModelConfiguration
    {
        public void ConfigureModel(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqLiteModelConfiguration).Assembly);
        }
    }
}
