﻿using System;

namespace EfDemo.Domain.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        
        public Guid AuthorGuid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Book> Books { get; set; } = new();
    }
}
