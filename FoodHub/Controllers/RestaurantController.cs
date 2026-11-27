using FoodHub.Data;
using FoodHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodHub.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly AppDbContext _context;

        public RestaurantController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var restaurants = await _context.Restaurants
                .Include(restaurant => restaurant.Reviews)
                .Include(restaurant => restaurant.MenuItems)
                .Include(restaurant => restaurant.Category)
                .ToListAsync();

            restaurants = restaurants.OrderByDescending(restaurant => restaurant.AverageRating).ToList();
            return View(restaurants);
        }

        public async Task<IActionResult> Details(int id)
        {
            var restaurant = await _context.Restaurants
                .Include(item => item.Reviews)
                .Include(item => item.MenuItems)
                .Include(item => item.Category)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (restaurant is null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                await LoadCategories();
                return View(restaurant);
            }

            _context.Add(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = restaurant.Id });
        }

        private async Task LoadCategories()
        {
            ViewBag.Categories = await _context.Categories.OrderBy(category => category.Name).ToListAsync();
        }
    }
}
