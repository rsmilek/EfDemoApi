using EfDemo.Api.Extensions;
using EfDemo.Domain.Abstractions;
using EfDemo.Domain.Entities;
using EfDemo.Domain.Extensions;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EfDemo.Api.Tests
{
    public class IntegrationTest
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public IntegrationTest()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
#if DEBUG
                    config.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
#else
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
#endif
                })
                .ConfigureServices((context, serviceCollection) =>
                {
                    serviceCollection.AddDomain();
                    var connectionString = context.Configuration.GetConnectionString("EfDemoDbConnection");
                    serviceCollection.AddInfrastructure(connectionString);
                });

            var host = builder.Build();

            _authorService = host.Services.GetRequiredService<IAuthorService>();
            _bookService = host.Services.GetRequiredService<IBookService>();
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
