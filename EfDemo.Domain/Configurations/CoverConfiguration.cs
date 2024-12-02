using EfDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace EfDemo.Domain.Configurations
{
    public class CoverConfiguration : IEntityTypeConfiguration<Cover>
    {
        public void Configure(EntityTypeBuilder<Cover> builder)
        {
            builder
                .ToTable("Covers");
            builder
                .Property(x => x.CoverColor)
                .HasConversion(c => c.ToString(), s => Color.FromName(s));
        }
    }
}