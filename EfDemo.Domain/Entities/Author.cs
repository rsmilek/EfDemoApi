﻿using System;

namespace EfDemo.Domain.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Book> Books { get; set; } = [];

        public ContactDetails? ContactDetails { get; set; }
        
        public List<string>? Nicknames { get; set; }
    }
}
