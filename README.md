This project focuses on creating a web API with an Entity Framework database backend with respect to the principles of structuring a project for cleanliness and testability.

## Table of Contents
- [Project structure](#project-structure)
- [Repository pattern](#repository-pattern)
- [Project layer resposibilities](#project-layer-resposibilities)
- [Testability](#testability)
- [Best practices](#best-practices)
- [Sources](#sources)


## Project structure
Application structure design with respect to separation of concerns (Layer - Concern):<br>
**_API_** - Representation, Authentication, Authorization, Paging<br>
**_Infrastructure_** - DB Schema Evolution (EF migrations), Sorting, Security<br>
**_Domain_** - Entity Relationships, Validation, Aggregation, Filtering<br>
**_Shared Kernel_** - Logging, Governance, Integration


## Repository pattern
Repository and specification from Entity Framework point of view:<br>
**_Repository_** - DbSet is collection of entities ready to use<br>
**_Specifications_** - LINQ expressions gives the means to express a specification for the entities to work with<br>
**_Database Interface_** - Query Providers abstracts the details of the persistence mechanism<br>


## Project layer resposibilities
Project layer resposibilities from Entity Framework point of view:

**_API_**<br>
Components: Controllers, DTOs, IoC config<br>
Packages: EF Core tools, Swashbuckle<br>

**_Infrastructure_**<br>
Components: Migrations<br>
Packages: EF Core SQL Server, EF Core SqIte, EF Core Xxx<br>

**_Domain_**<br>
Components: DbContext, Entities, Services<br>
Packages: EF Core<br>

**_Shared Kernel_**<br>
Components: Base classes, Interfaces, Cross-cutting concerns<br>
Packages: EF Core<br>


## Testability
The advantage of a layered application architecture is ease of testing:<br>
**_Unit Tests_** - are performed on top of the domain layer because of DbContext defined there.<br>
**_Integration Tests_** - are performed on top of the infrastructure layer that allows them to bring in the DB engine configration (SQL Server, SQLite) and make sure that things work against a real database.<br>
**_End to End tests_** - are performed on top of API layer because of that they can see how services interact with one another.<br>


## Best practices
- Use generic DBContextOptions
``` cs
    public EfDemoDbContext(DbContextOptions<EfDemoDbContext> options, IModelConfiguration modelConfiguration) : base(options)
    {
        _modelConfiguration = modelConfiguration;
    }
``` 
- Keep entity configurations isolated
``` cs
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly();
    }

    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .HasAlternateKey(x => x.AuthorGuid);
            ...
        }
    }
```
- Keep database configuration separate from application domain & Keep migrations separate from model<br>
Both of these practices are related to separation of concerns/application architecture (domain vs. infrastructure).
``` cs
    public static class SqlLiteServiceRegistration
    {
        public static IServiceCollection AddSqLiteInfrastructure(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<EfDemoDbContext>(options =>
            {
                options.UseSqlite(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(SqlLiteServiceRegistration).Assembly.FullName);
                })
            });
        
            return services;
        }
    }
``` 
- Configure dependencies at the top level
``` cs
    builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("EfDemoDbConnection"));
```
- Invert dependencies to defend separation of concerns & Rely upon the IoC container to satisfy dependencies<br>
Both of these practices are related to separation of concerns/application architecture (domain vs. infrastructure).<br>
If the Domain project requires something from the Infrastructre project, such as model configuration, use the IoC container - declare the interface to be consumed in Domain, implement it in Infrastructure, and use the IoC container for propagation.<br>

``` cs
    public interface IModelConfiguration
    {
        void ConfigureModel(ModelBuilder modelBuilder);
    }
```


## Sources
[EF Core 8 Fundamentals by Julie Lerman](https://app.pluralsight.com/library/courses/ef-core-8-fundamentals)<br>
[EF Core: Best Practices by Michael L Perry](https://app.pluralsight.com/library/courses/ef-core-6-best-practices)<br>
[Integration tests in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-9.0)
[What's new in .NET 8](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8/overview)
[What's New in EF Core 8](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew)
