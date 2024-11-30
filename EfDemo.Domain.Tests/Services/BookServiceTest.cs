using EfDemo.Domain.Entities;
using EfDemo.Domain.Services;
using FluentAssertions;

namespace EfDemo.Domain.Tests.Services
{
    public class BookServiceTest : ServiceTestBase
    {
        private readonly AuthorService _authorService;
        private readonly BookService _bookService;

        public BookServiceTest() : base()
        {
            _authorService = new AuthorService(Context);
            _bookService = new BookService(Context, _authorService);
        }

        [Fact]
        public async Task AddToAuthor_WhenBook_ReturnsBook()
        {
            // Arrange
            var expectedAuthor = new Author()
            {
                FirstName = "Radim",
                LastName = "Smilek"
            };
            var author = await _authorService.AddAsync(expectedAuthor);

            var expectedBook = new Book()
            {
                Title = "EF Book",
                PublishDate = new DateOnly(2024, 11, 1),
            };

            // Act
            var book = await _bookService.AddToAuthorByIdAsync(author.AuthorId, expectedBook);
            
            // Assert
            book.BookId.Should().NotBe(0);
        }
    }
}
