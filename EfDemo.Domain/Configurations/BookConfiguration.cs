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
                .HasAlternateKey(x => x.BookGuid);
            builder
                .Property(x => x.Title)
                .HasMaxLength(100);
        }
    }
}
