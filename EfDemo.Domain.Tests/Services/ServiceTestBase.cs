using EfDemo.SharedKernel.Configurations;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace EfDemo.Domain.Tests.Services
{
    public abstract class ServiceTestBase
    {
        protected readonly EfDemoDbContext Context;

        public ServiceTestBase()
        {
            var options = new DbContextOptionsBuilder<EfDemoDbContext>()
                .UseSqlite("Filename=:memory:")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            var modelConfiguration = new Mock<IModelConfiguration>();

            Context = new EfDemoDbContext(options, modelConfiguration.Object);
            
            Context.Database.OpenConnection();
            Context.Database.EnsureCreated();
        }
    }
}
