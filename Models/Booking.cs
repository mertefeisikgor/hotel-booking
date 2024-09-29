// Models/Booking.cs
using System.ComponentModel.DataAnnotations; // Required for data annotations
using System.ComponentModel.DataAnnotations.Schema; // Required for ForeignKey attribute

namespace HotelBooking.Models
{
    public class Booking
    {
        public int Id { get; set; } // Primary Key

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; } // Booking start date

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; } // Booking end date

        [Required(ErrorMessage = "Room is required.")]
        [ForeignKey("Room")]
        public int RoomId { get; set; } // Foreign Key to Room

        [Required(ErrorMessage = "Person is required.")]
        [ForeignKey("Person")]
        public int PersonId { get; set; } // Foreign Key to Person

        public Room Room { get; set; } = null!; // Navigation Property to Room (not nullable)
        public Person Person { get; set; } = null!; // Navigation Property to Person (not nullable)

        [Range(1, 5, ErrorMessage = "Star rating must be between 1 and 5.")]
        public int RatingOfStay { get; set; } // Star Rating (e.g., 1-5)

        [StringLength(200, ErrorMessage = "Comments cannot exceed 200 characters.")]
        public string? PersonComments { get; set; } // Nullable comments

        [Required(ErrorMessage = "Cleanup requested count is required.")]
        public int CleanUpRequestedCount { get; set; } = 0; // Default to 0 and not nullable
    }
}
