using CarExpress.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarExpress.Data.Configurations;

public class PictureConfiguration : IEntityTypeConfiguration<Picture>
{
    public void Configure(EntityTypeBuilder<Picture> builder)
    {
        builder.Property(picture => picture.FileName).HasMaxLength(300).IsRequired();
        builder.Property(picture => picture.FilePath).HasMaxLength(300).IsRequired();
    }
}