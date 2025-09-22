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
    }
}