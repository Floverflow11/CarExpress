using CarExpress.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarExpress.Data.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.Property(car => car.Vin).HasMaxLength(17).IsRequired(false);
        builder.Property(car => car.Description).HasMaxLength(3000).IsRequired(false);

        builder
            .HasOne(car => car.Sale)
            .WithOne(sale => sale.Car)
            .HasForeignKey<Sale>(sale => sale.CarId)
            .IsRequired();

        builder
            .HasMany(car => car.Pictures)
            .WithOne()
            .HasForeignKey(picture => picture.CarId)
            .IsRequired();

        builder.HasData(
            new Car
            {
                Id = 1, Year = 2019, BoughtDate = new DateOnly(2022, 1, 7), BoughtPrice = 1800, RepairCost = 7600,
                CanBeSoldFromDate = new DateOnly(2022, 4, 7), IsAvailable = true, TrimId = 1
            },
            new Car
            {
                Id = 2, Year = 2007, BoughtDate = new DateOnly(2022, 4, 2), BoughtPrice = 4500, RepairCost = 350,
                CanBeSoldFromDate = new DateOnly(2022, 4, 7), IsAvailable = true, TrimId = 2
            },
            new Car
            {
                Id = 3, Year = 2007, BoughtDate = new DateOnly(2022, 4, 4), BoughtPrice = 1800, RepairCost = 690,
                CanBeSoldFromDate = new DateOnly(2022, 4, 8), IsAvailable = true, TrimId = 3
            },
            new Car
            {
                Id = 4, Year = 2017, BoughtDate = new DateOnly(2022, 4, 5), BoughtPrice = 24350, RepairCost = 1100,
                CanBeSoldFromDate = new DateOnly(2022, 4, 9), IsAvailable = true, TrimId = 4
            },
            new Car
            {
                Id = 5, Year = 2008, BoughtDate = new DateOnly(2022, 4, 6), BoughtPrice = 4000, RepairCost = 475,
                CanBeSoldFromDate = new DateOnly(2022, 4, 9), IsAvailable = true, TrimId = 5
            },
            new Car
            {
                Id = 6, Year = 2016, BoughtDate = new DateOnly(2022, 4, 6), BoughtPrice = 15250, RepairCost = 440,
                CanBeSoldFromDate = new DateOnly(2022, 4, 10), IsAvailable = true, TrimId = 6
            },
            new Car
            {
                Id = 7, Year = 2013, BoughtDate = new DateOnly(2022, 4, 7), BoughtPrice = 10990, RepairCost = 950,
                CanBeSoldFromDate = new DateOnly(2022, 4, 11), IsAvailable = true, TrimId = 7
            }
        );
    }
}