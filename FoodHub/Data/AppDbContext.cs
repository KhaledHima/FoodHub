using FoodHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodHub.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<Review> Reviews => Set<Review>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasIndex(category => category.Slug)
            .IsUnique();

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasIndex(restaurant => restaurant.Slug).IsUnique();
            entity.Property(restaurant => restaurant.DeliveryFee).HasPrecision(10, 2);
            entity.Property(restaurant => restaurant.MinOrder).HasPrecision(10, 2);
            entity.HasOne(restaurant => restaurant.Category)
                .WithMany(category => category.Restaurants)
                .HasForeignKey(restaurant => restaurant.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.Property(menuItem => menuItem.Price).HasPrecision(10, 2);
            entity.HasOne(menuItem => menuItem.Restaurant)
                .WithMany(restaurant => restaurant.MenuItems)
                .HasForeignKey(menuItem => menuItem.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Review>()
            .HasOne(review => review.Restaurant)
            .WithMany(restaurant => restaurant.Reviews)
            .HasForeignKey(review => review.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);

        SeedData.Seed(modelBuilder);
    }
}
