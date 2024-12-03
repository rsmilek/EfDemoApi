using EfDemo.Domain.Abstractions;
using EfDemo.Domain.Entities;
using EfDemo.Domain.Services;
using EfDemo.Domain.Tests.Services;
using FluentAssertions;
using System.Drawing;

namespace EfDemo.Domain.Tests
{
    public class NewInEF8Test : ServiceTestBase
    {
        private readonly CoverService _coverService;

        public NewInEF8Test() : base()
        {
            _coverService = new CoverService(Context);
        }

        [Fact]
        public async Task ComplexProperty()
        {
            var expectedCover = new Cover()
            {
                CoverColor = Color.Red,
                Dimensions = new(width: 30, height: 40)
            };

            // Act
            var cover = await _coverService.AddAsync(expectedCover);

            // Assert
            cover.CoverId.Should().NotBe(0);
            cover.Dimensions.Should().Be(expectedCover.Dimensions);
        }
    }
}
