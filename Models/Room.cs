// Models/Room.cs
using System.ComponentModel.DataAnnotations; // Required for data annotations
using System.ComponentModel.DataAnnotations.Schema; // Required for foreign key attributes

namespace HotelBooking.Models
{
    public class Room
    {
        public int Id { get; set; } // Primary Key

        [Required] // Floor is required
        [StringLength(50)] // Limit length
        public string Floor { get; set; } // Floor number or name

        [Required] // Square meter is required
        [Range(1, int.MaxValue, ErrorMessage = "Square meter must be a positive number.")]
        public int SquareMeter { get; set; } // Square meter as an integer

        [Range(1, 5, ErrorMessage = "Quality rating must be between 1 and 5.")]
        public int QualityRating { get; set; } // Quality Rating (e.g., 1-5)

        [Required] // Make HotelId required
        [ForeignKey("Hotel")] // Specify foreign key relationship
        public int HotelId { get; set; } // Foreign key for Hotel

        // Navigation property for the related Hotel
        [Required] // Ensure the Hotel navigation property is also required
        public virtual Hotel Hotel { get; set; } // Navigation property
    }
}