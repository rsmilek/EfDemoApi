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
Packages: EF Core SQL Server, EF Core SqIte, ...<br>

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


## Sources
[EF Core 8 Fundamentals by Julie Lerman](https://app.pluralsight.com/library/courses/ef-core-8-fundamentals)<br>
[EF Core: Best Practices by Michael L Perry](https://app.pluralsight.com/library/courses/ef-core-6-best-practices)<br>
