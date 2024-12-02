using EfDemo.Domain.Entities;
using EfDemo.Domain.Enums;
using EfDemo.Domain.Services;
using EfDemo.Domain.Tests.Services;
using FluentAssertions;
using System.Drawing;

namespace EfDemo.Domain.Tests
{
    public class NewInEFCore2Test : ServiceTestBase
    {
        private readonly AuthorService _authorService;
        private readonly BookService _bookService;
        private readonly CoverService _coverService;

        public NewInEFCore2Test() : base()
        {
            _authorService = new AuthorService(Context);
            _bookService = new BookService(Context, _authorService);
            _coverService = new CoverService(Context);
        }

        [Fact]
        public async Task EnumConversion()
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
                Genre = BookGenre.Programming
            };

            // Act
            var book = await _bookService.AddToAuthorByIdAsync(author.AuthorId, expectedBook);

            // Assert
            book.BookId.Should().NotBe(0);
            book.Genre.Should().Be(expectedBook.Genre);
        }


        [Fact]
        public async Task ColorConversion()
        {
            // Arrange
            var expectedCover = new Cover()
            {
                CoverColor = Color.Red
            };

            // Act
            var cover = await _coverService.AddAsync(expectedCover);

            // Assert
            cover.CoverId.Should().NotBe(0);
            cover.CoverColor.Should().Be(expectedCover.CoverColor);
        }

    }
}
