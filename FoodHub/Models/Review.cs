using System.ComponentModel.DataAnnotations;

namespace FoodHub.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string? Comment { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Your name")]
        public string CustomerName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
