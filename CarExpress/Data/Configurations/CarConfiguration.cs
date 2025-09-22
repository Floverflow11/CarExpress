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
    }
}