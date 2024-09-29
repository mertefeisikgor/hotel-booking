// Models/Hotel.cs
using System.ComponentModel.DataAnnotations; // Required for data annotations

namespace HotelBooking.Models
{
    public class Hotel
    {
        public int Id { get; set; } // Primary Key

        [Required(ErrorMessage = "Hotel name is required.")]
        [StringLength(100, ErrorMessage = "Hotel name cannot exceed 100 characters.")]
        public string Name { get; set; } // Hotel Name

        [Required(ErrorMessage = "Hotel location is required.")]
        [StringLength(200, ErrorMessage = "Hotel location cannot exceed 200 characters.")]
        public string Location { get; set; } // Hotel Location

        [Range(1, 5, ErrorMessage = "Star rating must be between 1 and 5.")]
        public int Rating { get; set; } // Star Rating (e.g., 1-5)
    }
}
