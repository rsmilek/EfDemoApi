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
                .ToTable("Authors");
            builder
                .Property(x => x.FirstName)
                .HasMaxLength(100);
            builder
                .Property(x => x.LastName)
                .HasMaxLength(100);
            // Sub-type as JSON (new in EF7)
            builder
                .OwnsOne(x => x.ContactDetails, navigrationBuilder => navigrationBuilder.ToJson());
        }
    }
}
