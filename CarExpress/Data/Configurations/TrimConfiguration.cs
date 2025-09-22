using CarExpress.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarExpress.Data.Configurations;

public class TrimConfiguration : IEntityTypeConfiguration<Trim>
{
    public void Configure(EntityTypeBuilder<Trim> builder)
    {
        builder.Property(trim => trim.Name).HasMaxLength(50).IsRequired();

        builder
            .HasMany<Car>()
            .WithOne(car => car.Trim)
            .HasForeignKey(car => car.TrimId)
            .IsRequired();
    }
}