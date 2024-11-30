using EfDemo.Domain.Entities;
using EfDemo.SharedKernel.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDemo.Domain
{
    public class EfDemoDbContext : DbContext
    {
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<Book> Books { get; set; }

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


    public class EfDemoDbContext2 : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog=EfDemoDb;"
            //"Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog=PubDatabase;"
            ).LogTo(Console.WriteLine,
                    new[] { DbLoggerCategory.Database.Command.Name },
                    LogLevel.Information)
            .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(x => x.FirstName)
                .HasMaxLength(100);
            modelBuilder.Entity<Author>()
                .Property(x => x.LastName)
                .HasMaxLength(100);


            modelBuilder.Entity<Book>()
                .Property(x => x.Title)
                .HasMaxLength(100);
            modelBuilder.Entity<Book>()
                .Property(x => x.BasePrice)
                .HasPrecision(18, 2);
        }
    }

}
