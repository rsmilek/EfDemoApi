using EfDemo.Domain.Entities;
using EfDemo.Domain.Services;
using EfDemo.Domain.Tests.Services;
using FluentAssertions;

namespace EfDemo.Domain.Tests
{
    public class NewInEFCore5Test : ServiceTestBase
    {
        private readonly AuthorService _authorService;
        private readonly BookService _bookService;

        public NewInEFCore5Test() : base()
        {
            _authorService = new AuthorService(Context);
            _bookService = new BookService(Context, _authorService);
        }

        [Fact]
        public async Task FilteringAndSortingIncludedData()
        {
            // Arrange
            var author1 = new Author 
            { 
                FirstName = "Rhoda", 
                LastName = "Lerman" 
            };
            await _authorService.AddAsync(author1);
            
            var book1 = new Book
            {
                Title = "In God's Ear",
                PublishDate = new DateOnly(1989, 3, 1)
            };
            await _bookService.AddToAuthorByIdAsync(author1.AuthorId, book1);


            var author2 = new Author
            {
                FirstName = "Ruth",
                LastName = "Ozeki"
            };
            await _authorService.AddAsync(author2);

            var book2 = new Book
            {
                Title = "A Tale For the Time Being",
                PublishDate = new DateOnly(2013, 12, 31)
            };
            await _bookService.AddToAuthorByIdAsync(author2.AuthorId, book2);


            var author3 = new Author
            {
                FirstName = "Sofia",
                LastName = "Segovia"
            };
            await _authorService.AddAsync(author3);

            var book3 = new Book
            {
                Title = "The Left Hand of Darkness",
                PublishDate = new DateOnly(1969, 3, 1)
            };
            await _bookService.AddToAuthorByIdAsync(author3.AuthorId, book3);

            var publishDataMin = new DateOnly(2010, 1, 1);
            var expectedAuthorWithBookIds = new List<Author> { author1, author2, author3 }
                .Select(a => new { a.AuthorId, BookIds = a.Books.Where(b => b.PublishDate >= publishDataMin).Select(b => b.BookId) });

            // Act
            var authors = await _authorService.GetAuthorsWthBooksAsync(publishDataMin);

            // Assert
            authors.Select(a => new { a.AuthorId, BookIds = a.Books.Select(b => b.BookId) })
            .Should().BeEquivalentTo(expectedAuthorWithBookIds);
        }
    }
}
