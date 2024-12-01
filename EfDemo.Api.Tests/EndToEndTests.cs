using EfDemo.Api.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace EfDemo.Api.Tests
{
    public partial class EndToEndTests
    {
        [Fact]
        public async Task ApiIsRunning()
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            // Act
            var response = await client.GetStringAsync("/api/author");

            // Assert
            response.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task PostAuthor_WhenAuthor_ReturnsAuthor()
        {
            // Arrange
            var authorDTO = new AuthorDTO 
            { 
                AuthorId = 0, 
                FirstName = "Radim", 
                LastName = "Smilek" 
            };
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/api/author", authorDTO);
            var expecteAuthorDTO = await response.Content.ReadFromJsonAsync<AuthorDTO>();

            // Assert
            expecteAuthorDTO.Should().NotBeNull();
            expecteAuthorDTO.AuthorId.Should().NotBe(0);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}