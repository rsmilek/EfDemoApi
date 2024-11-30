using EfDemo.Domain.Entities;
using EfDemo.Domain.Services;
using FluentAssertions;

namespace EfDemo.Domain.Tests.Services
{
    public class AuthorServiceTest : ServiceTestBase
    {
        private readonly AuthorService _authorService;

        public AuthorServiceTest() : base()
        {
            _authorService = new AuthorService(Context);
        }

        [Fact]
        public async Task Add_WhenAuthor_ReturnsAuthor()
        {
            // Arrange
            var expectedAuthor = new Author()
            {
                FirstName = "Radim",
                LastName = "Smilek"
            };

            // Act
            var author = await _authorService.AddAsync(expectedAuthor);

            // Assert
            author.AuthorId.Should().NotBe(0);
        }
    }
}
