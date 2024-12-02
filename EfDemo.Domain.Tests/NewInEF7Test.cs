using EfDemo.Domain.Entities;
using EfDemo.Domain.Services;
using EfDemo.Domain.Tests.Services;
using FluentAssertions;

namespace EfDemo.Domain.Tests
{
    public class NewInEF7Test : ServiceTestBase
    {
        private readonly AuthorService _authorService;

        public NewInEF7Test() : base()
        {
            _authorService = new AuthorService(Context);
        }

        [Fact]
        public async Task SubTypeAsJSON()
        {
            // Arrange
            var expectedAuthor = new Author()
            {
                FirstName = "Radim",
                LastName = "Smilek",
                ContactDetails = new ContactDetails()
                {
                    EmailAddress = "radim.smilek@cz.abb.com",
                    Phone = "+420 733 693 329"
                }
            };

            // Act
            var author = await _authorService.AddAsync(expectedAuthor);

            // Assert
            author.AuthorId.Should().NotBe(0);
            author.ContactDetails.Should().BeEquivalentTo(expectedAuthor.ContactDetails);
        }

        [Fact]
        public async Task PrimitiveCollectionsAsJSON()
        {
            // Arrange
            var expectedAuthor = new Author()
            {
                FirstName = "Radim",
                LastName = "Smilek",
                Nicknames = ["RSm", "Smila"]
            };

            // Act
            var author = await _authorService.AddAsync(expectedAuthor);

            // Assert
            author.AuthorId.Should().NotBe(0);
            author.Nicknames.Should().BeEquivalentTo(expectedAuthor.Nicknames);
        }
    }
}
