using FoodHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodHub.Data;

public static class SeedData
{
    private static readonly DateTime Seeded = new(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Egyptian", Slug = "egyptian", Icon = "🥙" },
            new Category { Id = 2, Name = "Pizza", Slug = "pizza", Icon = "🍕" },
            new Category { Id = 3, Name = "Grill", Slug = "grill", Icon = "🍖" },
            new Category { Id = 4, Name = "Burgers", Slug = "burgers", Icon = "🍔" },
            new Category { Id = 5, Name = "Desserts", Slug = "desserts", Icon = "🍰" },
            new Category { Id = 6, Name = "Seafood", Slug = "seafood", Icon = "🦐" });

        modelBuilder.Entity<Restaurant>().HasData(
            Restaurant(1, "Koshary El Tahrir", "koshary-el-tahrir", 1, "The classic koshary everyone loves.", "Gomhoreya St, Assiut", "01012345678", 15, 50, 25, true),
            Restaurant(2, "Pizza Corner", "pizza-corner", 2, "Stone-baked pizza with fresh dough.", "University St, Assiut", "01112345678", 20, 100, 35, true),
            Restaurant(3, "Grill House", "grill-house", 3, "Kofta, kebab and mixed grills.", "Nile Corniche, Assiut", "01212345678", 25, 150, 40, false),
            Restaurant(4, "Burger Lab", "burger-lab", 4, "Smash burgers and loaded fries.", "Al Hamraa, Assiut", "01512345678", 20, 80, 30, true),
            Restaurant(5, "Sweet Tooth", "sweet-tooth", 5, "Konafa, basbousa and cakes.", "Gamal Abdel Nasser St, Assiut", "01022223333", 10, 40, 20, true),
            Restaurant(6, "Sea Breeze", "sea-breeze", 6, "Fresh fish and shrimp daily.", "Nile Corniche, Assiut", "01133334444", 30, 200, 45, true),
            Restaurant(7, "Abo Tarek Foul", "abo-tarek-foul", 1, "Foul, falafel and Egyptian breakfast.", "Station Sq, Assiut", "01244445555", 10, 30, 15, true),
            Restaurant(8, "Napoli Express", "napoli-express", 2, "Italian pizza and pasta.", "Al Walideya, Assiut", "01055556666", 25, 120, 35, true));

        var id = 0;
        MenuItem MenuItem(int restaurant, string name, decimal price, string? description = null, bool popular = false) =>
            new() { Id = ++id, RestaurantId = restaurant, Name = name, Price = price, Description = description, IsPopular = popular, IsAvailable = true };

        modelBuilder.Entity<MenuItem>().HasData(
            MenuItem(1, "Koshary Large", 45, "Rice, pasta, lentils, crispy onions", true), MenuItem(1, "Koshary Medium", 35), MenuItem(1, "Rice Pudding", 20),
            MenuItem(2, "Margherita", 120, "Tomato, mozzarella, basil", true), MenuItem(2, "Pepperoni", 150), MenuItem(2, "Chicken Ranch", 165),
            MenuItem(3, "Mixed Grill 1kg", 520, "Kofta, kebab, shish tawook", true), MenuItem(3, "Kofta 1/2kg", 260), MenuItem(3, "Grilled Chicken", 210),
            MenuItem(4, "Classic Smash", 140, "Double patty, cheddar, pickles", true), MenuItem(4, "Mushroom Swiss", 165), MenuItem(4, "Loaded Fries", 75),
            MenuItem(5, "Konafa with Cream", 70, popular: true), MenuItem(5, "Basbousa", 40), MenuItem(5, "Molten Cake", 85),
            MenuItem(6, "Grilled Sea Bream", 280, popular: true), MenuItem(6, "Shrimp Tagine", 320), MenuItem(6, "Calamari", 240),
            MenuItem(7, "Foul Sandwich", 10, popular: true), MenuItem(7, "Falafel Sandwich", 10), MenuItem(7, "Breakfast Box", 60),
            MenuItem(8, "Quattro Formaggi", 185, popular: true), MenuItem(8, "Penne Arrabbiata", 130), MenuItem(8, "Tiramisu", 90));

        modelBuilder.Entity<Review>().HasData(
            new Review { Id = 1, RestaurantId = 1, Rating = 5, CustomerName = "Mona", Comment = "Best koshary in Assiut!", CreatedAt = Seeded },
            new Review { Id = 2, RestaurantId = 1, Rating = 4, CustomerName = "Karim", Comment = "Great taste, a bit slow.", CreatedAt = Seeded },
            new Review { Id = 3, RestaurantId = 2, Rating = 4, CustomerName = "Sara", Comment = "Crispy crust 👌", CreatedAt = Seeded },
            new Review { Id = 4, RestaurantId = 3, Rating = 5, CustomerName = "Omar", Comment = "The mixed grill is huge.", CreatedAt = Seeded },
            new Review { Id = 5, RestaurantId = 4, Rating = 3, CustomerName = "Nada", Comment = "Good burger, cold fries.", CreatedAt = Seeded },
            new Review { Id = 6, RestaurantId = 5, Rating = 5, CustomerName = "Youssef", Comment = "Konafa ❤️", CreatedAt = Seeded });
    }

    private static Restaurant Restaurant(int id, string name, string slug, int categoryId, string description, string address, string phone, decimal deliveryFee, decimal minOrder, int deliveryMinutes, bool isOpen) =>
        new()
        {
            Id = id,
            Name = name,
            Slug = slug,
            CategoryId = categoryId,
            Description = description,
            Address = address,
            Phone = phone,
            DeliveryFee = deliveryFee,
            MinOrder = minOrder,
            DeliveryMinutes = deliveryMinutes,
            IsOpen = isOpen,
            CreatedAt = Seeded
        };
}
