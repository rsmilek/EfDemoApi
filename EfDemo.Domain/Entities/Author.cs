using System;
using System.Data.SqlTypes;

namespace EfDemo.Domain.Entities
{
    // Nullable reference types (new in C# 8.0 / NET 6)
    // Possible nullability solutions:
    // 1. Declare optional entity columns as nullable
    // 2. Initialize non-nullable navigation properties in a public constructor
    // 3. Use null-forgiving operator only when something else is keeping you safe:
    //   - Entity Framework initializing DbSet
    //   - Database constraint enforcing non-null foreign key
    public class Author
    {
        public int AuthorId { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public List<Book> Books { get; set; } = [];

        public ContactDetails? ContactDetails { get; set; }
        
        public List<string>? Nicknames { get; set; }
    }
}
