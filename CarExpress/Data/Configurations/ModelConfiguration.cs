using CarExpress.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarExpress.Data.Configurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.Property(model => model.Name).HasMaxLength(50).IsRequired();

        builder
            .HasMany(model => model.Trims)
            .WithOne(trim => trim.Model)
            .HasForeignKey(trim => trim.ModelId)
            .IsRequired();

        builder.HasData(
            new Model { Id = 1, Name = "Miata", BrandId = 1 },
            new Model { Id = 2, Name = "Liberty", BrandId = 2 },
            new Model { Id = 3, Name = "Scénic", BrandId = 3 },
            new Model { Id = 4, Name = "Explorer", BrandId = 4 },
            new Model { Id = 5, Name = "Civic", BrandId = 5 },
            new Model { Id = 6, Name = "GTI", BrandId = 6 },
            new Model { Id = 7, Name = "Edge", BrandId = 4 });
    }
}