using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace FoodHub.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryFee = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    MinOrder = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    DeliveryMinutes = table.Column<int>(type: "int", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsPopular = table.Column<bool>(type: "bit", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Icon", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "🥙", "Egyptian", "egyptian" },
                    { 2, "🍕", "Pizza", "pizza" },
                    { 3, "🍖", "Grill", "grill" },
                    { 4, "🍔", "Burgers", "burgers" },
                    { 5, "🍰", "Desserts", "desserts" },
                    { 6, "🦐", "Seafood", "seafood" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "CategoryId", "CreatedAt", "DeliveryFee", "DeliveryMinutes", "Description", "IsOpen", "MinOrder", "Name", "Phone", "Slug" },
                values: new object[,]
                {
                    { 1, "Gomhoreya St, Assiut", 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 15m, 25, "The classic koshary everyone loves.", true, 50m, "Koshary El Tahrir", "01012345678", "koshary-el-tahrir" },
                    { 2, "University St, Assiut", 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20m, 35, "Stone-baked pizza with fresh dough.", true, 100m, "Pizza Corner", "01112345678", "pizza-corner" },
                    { 3, "Nile Corniche, Assiut", 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 25m, 40, "Kofta, kebab and mixed grills.", false, 150m, "Grill House", "01212345678", "grill-house" },
                    { 4, "Al Hamraa, Assiut", 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20m, 30, "Smash burgers and loaded fries.", true, 80m, "Burger Lab", "01512345678", "burger-lab" },
                    { 5, "Gamal Abdel Nasser St, Assiut", 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10m, 20, "Konafa, basbousa and cakes.", true, 40m, "Sweet Tooth", "01022223333", "sweet-tooth" },
                    { 6, "Nile Corniche, Assiut", 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 30m, 45, "Fresh fish and shrimp daily.", true, 200m, "Sea Breeze", "01133334444", "sea-breeze" },
                    { 7, "Station Sq, Assiut", 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10m, 15, "Foul, falafel and Egyptian breakfast.", true, 30m, "Abo Tarek Foul", "01244445555", "abo-tarek-foul" },
                    { 8, "Al Walideya, Assiut", 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 25m, 35, "Italian pizza and pasta.", true, 120m, "Napoli Express", "01055556666", "napoli-express" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "IsAvailable", "IsPopular", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Rice, pasta, lentils, crispy onions", true, true, "Koshary Large", 45m, 1 },
                    { 2, null, true, false, "Koshary Medium", 35m, 1 },
                    { 3, null, true, false, "Rice Pudding", 20m, 1 },
                    { 4, "Tomato, mozzarella, basil", true, true, "Margherita", 120m, 2 },
                    { 5, null, true, false, "Pepperoni", 150m, 2 },
                    { 6, null, true, false, "Chicken Ranch", 165m, 2 },
                    { 7, "Kofta, kebab, shish tawook", true, true, "Mixed Grill 1kg", 520m, 3 },
                    { 8, null, true, false, "Kofta 1/2kg", 260m, 3 },
                    { 9, null, true, false, "Grilled Chicken", 210m, 3 },
                    { 10, "Double patty, cheddar, pickles", true, true, "Classic Smash", 140m, 4 },
                    { 11, null, true, false, "Mushroom Swiss", 165m, 4 },
                    { 12, null, true, false, "Loaded Fries", 75m, 4 },
                    { 13, null, true, true, "Konafa with Cream", 70m, 5 },
                    { 14, null, true, false, "Basbousa", 40m, 5 },
                    { 15, null, true, false, "Molten Cake", 85m, 5 },
                    { 16, null, true, true, "Grilled Sea Bream", 280m, 6 },
                    { 17, null, true, false, "Shrimp Tagine", 320m, 6 },
                    { 18, null, true, false, "Calamari", 240m, 6 },
                    { 19, null, true, true, "Foul Sandwich", 10m, 7 },
                    { 20, null, true, false, "Falafel Sandwich", 10m, 7 },
                    { 21, null, true, false, "Breakfast Box", 60m, 7 },
                    { 22, null, true, true, "Quattro Formaggi", 185m, 8 },
                    { 23, null, true, false, "Penne Arrabbiata", 130m, 8 },
                    { 24, null, true, false, "Tiramisu", 90m, 8 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "CustomerName", "Rating", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Best koshary in Assiut!", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mona", 5, 1 },
                    { 2, "Great taste, a bit slow.", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Karim", 4, 1 },
                    { 3, "Crispy crust 👌", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sara", 4, 2 },
                    { 4, "The mixed grill is huge.", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Omar", 5, 3 },
                    { 5, "Good burger, cold fries.", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Nada", 3, 4 },
                    { 6, "Konafa ❤️", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Youssef", 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Slug",
                table: "Categories",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_RestaurantId",
                table: "MenuItems",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CategoryId",
                table: "Restaurants",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_Slug",
                table: "Restaurants",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RestaurantId",
                table: "Reviews",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
