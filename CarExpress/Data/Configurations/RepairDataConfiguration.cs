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
    }
}