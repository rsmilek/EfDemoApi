using Microsoft.EntityFrameworkCore;

namespace EfDemo.SharedKernel.Configuration;

public interface IModelConfiguration
{
    void ConfigureModel(ModelBuilder modelBuilder);
}
