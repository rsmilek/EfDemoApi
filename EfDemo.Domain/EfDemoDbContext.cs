using EfDemo.SharedKernel.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EfDemo.Domain
{
    public class EfDemoDbContext : DbContext
    {
        private readonly IModelConfiguration _modelConfiguration;

        public EfDemoDbContext(DbContextOptions<EfDemoDbContext> options, IModelConfiguration modelConfiguration) : base(options)
        {
            _modelConfiguration = modelConfiguration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDemoDbContext).Assembly);
            _modelConfiguration.ConfigureModel(modelBuilder);
        }
    }
}
