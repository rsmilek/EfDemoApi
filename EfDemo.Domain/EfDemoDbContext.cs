using EfDemo.SharedKernel.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace EfDemo.Domain
{
    public class EfDemoDbContext : DbContext
    {
        private readonly IModelConfiguration modelConfiguration;

        public EfDemoDbContext(DbContextOptions<EfDemoDbContext> options, IModelConfiguration modelConfiguration)
            : base(options)
        {
            this.modelConfiguration = modelConfiguration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDemoDbContext).Assembly);
            modelConfiguration.ConfigureModel(modelBuilder);
        }
    }
}
