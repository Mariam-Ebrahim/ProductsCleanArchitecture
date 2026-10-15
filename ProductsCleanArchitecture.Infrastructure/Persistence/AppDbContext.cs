using Microsoft.EntityFrameworkCore;
using ProductsCleanArchitecture.Domain.Entities;

namespace ProductsCleanArchitecture.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(p => p.Price)
                  .HasPrecision(18, 2);
        });
    }
}