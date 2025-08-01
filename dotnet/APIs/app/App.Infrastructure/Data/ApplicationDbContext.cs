using App.Domain.Entities;
using App.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Branch> Branches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>().HasKey(x => x.Id);
        modelBuilder.Entity<Restaurant>().Property(x => x.Name)
                    .HasMaxLength(5)
                    .IsRequired();

        modelBuilder.Entity<Branch>().HasKey(x => x.Id);
        modelBuilder.Entity<Branch>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(x => x.Value).HasColumnName("Email").IsRequired();
            });
            builder.OwnsOne(x => x.Contact, contact =>
            {
                contact.Property(p => p.CounrtyCode).HasColumnName("CountryCode");
                contact.Property(p => p.Number).HasColumnName("PhoneNumber").IsRequired();
            });
        });

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Books" },
            new Category { Id = 3, Name = "Clothing" }
        );
    }
}