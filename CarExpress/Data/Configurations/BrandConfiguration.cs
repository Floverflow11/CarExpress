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

        builder.HasData(
            new Brand { Id = 1, Name = "Mazda" },
            new Brand { Id = 2, Name = "Jeep" },
            new Brand { Id = 3, Name = "Renault" },
            new Brand { Id = 4, Name = "Ford" },
            new Brand { Id = 5, Name = "Honda" },
            new Brand { Id = 6, Name = "Volkswagen" });
    }
}