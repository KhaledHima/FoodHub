using System.ComponentModel.DataAnnotations;

namespace FoodHub.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(300)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Range(1, 5000)]
        [DataType(DataType.Currency)]
        [Display(Name = "Price (EGP)")]
        public decimal Price { get; set; }

        [Display(Name = "Available")]
        public bool IsAvailable { get; set; } = true;

        [Display(Name = "Popular 🔥")]
        public bool IsPopular { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
