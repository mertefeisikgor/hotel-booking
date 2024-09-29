// Data/HotelBookingContext.cs
using Microsoft.EntityFrameworkCore;
using HotelBooking.Models; // Ensure this is present

namespace HotelBooking.Data
{
    public class HotelBookingContext : DbContext
    {
        public HotelBookingContext(DbContextOptions<HotelBookingContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        // Other DbSet properties...
    }
}