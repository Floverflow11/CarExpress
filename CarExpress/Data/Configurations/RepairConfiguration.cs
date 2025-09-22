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
                je =>
                {
                    je.HasKey("CarId", "RepairId");
                    je.HasData(
                        new { CarId = 1, RepairId = 1 },
                        new { CarId = 2, RepairId = 2 },
                        new { CarId = 3, RepairId = 3 },
                        new { CarId = 3, RepairId = 4 }
                    );
                }
            );

        builder.HasData(
            new Repair { Id = 1, RepairDataId = 1 },
            new Repair { Id = 2, RepairDataId = 2 },
            new Repair { Id = 3, RepairDataId = 3 },
            new Repair { Id = 4, RepairDataId = 4 }
        );
    }
}