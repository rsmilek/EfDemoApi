using EfDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDemo.Domain.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .ToTable("Books");
            builder
                .Property(x => x.Title)
                .HasMaxLength(100);
            builder
                .Property(x => x.BasePrice)
                .HasPrecision(18, 2);
            // New in EF Core 2.1
            builder
                .Property(x => x.Genre)
                .HasConversion<string>();
        }
    }
}
