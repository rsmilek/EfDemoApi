using EfDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDemo.Domain.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .HasAlternateKey(x => x.AuthorGuid);
            builder
                .Property(x => x.FirstName)
                .HasMaxLength(100);
            builder
                .Property(x => x.LastName)
                .HasMaxLength(100);
        }
    }
}
