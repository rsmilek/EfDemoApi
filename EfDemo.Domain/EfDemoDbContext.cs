using EfDemo.Domain.Entities;
using EfDemo.SharedKernel.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EfDemo.Domain
{
    public class EfDemoDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

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
