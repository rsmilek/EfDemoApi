﻿using EfDemo.SharedKernel.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EfDemo.Infrastructure.SqlServer.Configurations
{
    public class SqlModelConfiguration : IModelConfiguration
    {
        public void ConfigureModel(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlModelConfiguration).Assembly);
        }
    }
}
