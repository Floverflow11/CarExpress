using CarExpress.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarExpress.Data.Configurations;

public class RepairConfiguration : IEntityTypeConfiguration<Repair>
{
    public void Configure(EntityTypeBuilder<Repair> builder)
    {
        builder
            .HasMany(repair => repair.Cars)
            .WithMany(car => car.Repairs)
            .UsingEntity(
                "CarRepair",
                l => l.HasOne(typeof(Car))
                    .WithMany()
                    .HasForeignKey("CarId"),
                r => r.HasOne(typeof(Repair))
                    .WithMany()
                    .HasForeignKey("RepairId"),
                je => je.HasKey("CarId", "RepairId")
            );
    }
}