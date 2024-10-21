# EfDemoApi
This project focuses on creating a web API with an Entity Framework database backend with respect to the principles of structuring a project for cleanliness and testability.

## Table of Contents
- [Project structure](#project-structure)
- [Repository pattern](#repository-pattern)
- [Project layer resposibilities](#project-layer-resposibilities)
- [Testability](testability)
- [Best practices](#best-practices)
- [Sources](#sources)


## Project structure
Application structure design with respect to separation of concerns (Layer - Concern):

_API_ - Representation, Authentication, Authorization, Paging

_Infrastructure_ - DB Schema Evolution (EF migrations), Sorting, Security

_Domain_ - Entity Relationships, Validation, Aggregation, Filtering

_Shared Kernel_ - Logging, Governance, Integration


## Repository pattern
Repository and specification from Entity Framework point of view:

_Repository_ - DbSet is collection of entities ready to use

_Specifications_ - LINQ expressions gives the means to express a specification for the entities to work with

_Database Interface_ - Query Providers abstracts the details of the persistence mechanism


## Project layer resposibilities
Project layer resposibilities from Entity Framework point of view:

_API_
  - Components: Controllers, DTOs, IoC config
  - Packages: EF Core tools, Swashbuckle 

_Infrastructure_
  - Components: Migrations
  - Packages: EF Core SQL Server, EF Core SqIte, ...

_Domain_
  - Components: DbContext, Entities, Services 
  - Packages: EF Core

_Shared Kernel_
  - Components: Base classes, Interfaces, Cross-cutting concerns 
  - Packages: EF Core


## Testability
The advantage of a layered application architecture is ease of testing:

_Unit Tests_ - are performed on top of the domain layer because of DbContext defined there. 

_Integration Tests_ - are performed on top of the infrastructure layer that allows them to bring in the DB engine configration (SQL Server, SQLite) and make sure that things work against a real database.

_End to End tests_ - are performed on top of API layer because of that they can see how services interact with one another.


## Best practices



## Sources
[EF Core 8 Fundamentals](https://app.pluralsight.com/library/courses/ef-core-8-fundamentals) by Julie Lerman<br>
[EF Core: Best Practices](https://app.pluralsight.com/library/courses/ef-core-6-best-practices/) by Michael L Perry 
