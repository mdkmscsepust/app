using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Data;

public class ApplicationDbContext : DbContext
{
    // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    // {
    // }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure entity properties, relationships, etc.
        modelBuilder.Entity<Product>()
            .Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(100);
        // Add more configurations as needed
    }
}