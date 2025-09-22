using CarExpress.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarExpress.Data.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(brand => brand.Name).HasMaxLength(50).IsRequired();

        builder
            .HasMany(brand => brand.Models)
            .WithOne(model => model.Brand)
            .HasForeignKey(model => model.BrandId)
            .IsRequired();
    }
}