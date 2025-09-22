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

        builder.HasData(
            new Trim { Id = 1, Name = "LE", ModelId = 1 },
            new Trim { Id = 2, Name = "Sport", ModelId = 2 },
            new Trim { Id = 3, Name = "TCe", ModelId = 3 },
            new Trim { Id = 4, Name = "XLT", ModelId = 4 },
            new Trim { Id = 5, Name = "LX", ModelId = 5 },
            new Trim { Id = 6, Name = "S", ModelId = 6 },
            new Trim { Id = 7, Name = "SEL", ModelId = 7 });
    }
}