using System;
using System.ComponentModel.DataAnnotations; // Add this using directive

namespace HotelBooking.Models
{
    public class Person
    {
        public int Id { get; set; }  // Primary Key

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }         // First Name

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }          // Last Name

        [Phone]
        public string PhoneNumber { get; set; }       // Phone Number

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }       // Birth Date

        // Set CreatedAt to use UTC
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Set default to current UTC time
    }
}