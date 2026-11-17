using FoodHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodHub.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly List<Restaurant> restaurants = new List<Restaurant> ()
        {
      
                new Restaurant { Id = 1, Name = "Pasta Palace", Cuisine = "Italian", Rating = 4.5, DeliveryFee = 2.99, DeliveryMinutes = 30, IsOpen = true },
                new Restaurant { Id = 2, Name = "Sushi Central", Cuisine = "Japanese", Rating = 4.8, DeliveryFee = 3.49, DeliveryMinutes = 25, IsOpen = false },
                new Restaurant { Id = 3, Name = "Taco Town", Cuisine = "Mexican", Rating = 4.2, DeliveryFee = 1.99, DeliveryMinutes = 20, IsOpen = true },
                new Restaurant { Id = 4, Name = "Burger Barn", Cuisine = "American", Rating = 4.0, DeliveryFee = 2.49, DeliveryMinutes = 15, IsOpen = true },
                new Restaurant { Id = 5, Name = "Curry Corner", Cuisine = "Indian", Rating = 4.6, DeliveryFee = 2.79, DeliveryMinutes = 35, IsOpen = false }
    };
        public IActionResult Index()
        { var Restaurants = restaurants.Where(r => r.IsOpen).ToList();
            return View(Restaurants);
        }
    }
}
