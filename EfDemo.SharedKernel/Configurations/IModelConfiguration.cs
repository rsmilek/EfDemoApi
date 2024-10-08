using Microsoft.EntityFrameworkCore;

namespace EfDemo.SharedKernel.Configurations;

public interface IModelConfiguration
{
    void ConfigureModel(ModelBuilder modelBuilder);
}
