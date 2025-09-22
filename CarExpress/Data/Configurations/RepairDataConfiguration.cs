using CarExpress.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarExpress.Data.Configurations;

public class RepairDataConfiguration : IEntityTypeConfiguration<RepairData>
{
    public void Configure(EntityTypeBuilder<RepairData> builder)
    {
        builder.Property(data => data.Name).HasMaxLength(150).IsRequired();

        builder
            .HasMany(data => data.Repairs)
            .WithOne(repair => repair.RepairData)
            .HasForeignKey(repair => repair.RepairDataId)
            .IsRequired();

        builder.HasData(
            new RepairData { Id = 1, Name = "Restauration complète" },
            new RepairData { Id = 2, Name = "Roulements des roues avant" },
            new RepairData { Id = 3, Name = "Radiateur" },
            new RepairData { Id = 4, Name = "Freins" },
            new RepairData { Id = 5, Name = "Pneus" },
            new RepairData { Id = 6, Name = "Climatisation" });
    }
}