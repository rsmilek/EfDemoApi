﻿using EfDemo.Domain.Enums;
using System;

namespace EfDemo.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        // DateOnly, TimeOnly (new in EF8)
        public DateOnly PublishDate { get; set; }
        
        public decimal BasePrice { get; set; }
        
        public Author Author { get; set; }
        
        public int AuthorId { get; set; }

        public BookGenre? Genre { get; set; }
    }
}
