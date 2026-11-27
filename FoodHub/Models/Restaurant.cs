using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodHub.Validation;

namespace FoodHub.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Restaurant name is required")]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Restaurant name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(60)]
        [RegularExpression("^[a-z0-9]+(-[a-z0-9]+)*$", ErrorMessage = "Slug: lowercase letters, numbers and dashes only")]
        public string Slug { get; set; } = string.Empty;

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [EgyptianPhone]
        [Display(Name = "Phone number")]
        public string Phone { get; set; } = string.Empty;

        [Range(0, 200)]
        [DataType(DataType.Currency)]
        [Display(Name = "Delivery fee (EGP)")]
        public decimal DeliveryFee { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Minimum order (EGP)")]
        public decimal MinOrder { get; set; }

        [Range(10, 120)]
        [Display(Name = "Delivery time (min)")]
        public int DeliveryMinutes { get; set; } = 30;

        [Display(Name = "Open now")]
        public bool IsOpen { get; set; } = true;

        [DataType(DataType.Date)]
        [Display(Name = "Joined")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Cuisine")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<MenuItem> MenuItems { get; set; } = [];
        public List<Review> Reviews { get; set; } = [];

        [NotMapped]
        [Display(Name = "Rating")]
        public double AverageRating => Reviews.Count == 0 ? 0 : Math.Round(Reviews.Average(review => review.Rating), 1);
    }
}
