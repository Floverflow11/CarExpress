using CarExpress.Data.Configurations;
using CarExpress.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarExpress.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Trim> Trims { get; set; }
    public DbSet<RepairData> RepairData { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Repair> Repairs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarConfiguration).Assembly);
    }
}