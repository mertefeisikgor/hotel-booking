using HotelBooking.Models;
using HotelBooking.Data; // Make sure to include your data context
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Add this using directive for Task

namespace HotelBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly HotelBookingContext _context;

        public BookingService(HotelBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            return await _context.Bookings
                                 .Include(b => b.Room)
                                 .Include(b => b.Person)
                                 .ToListAsync();
        }

        public async Task<Booking> GetBookingById(int id)
        {
            return await _context.Bookings
                                 .Include(b => b.Room)
                                 .Include(b => b.Person)
                                 .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Booking> CreateBooking(Booking newBooking)
        {
            await _context.Bookings.AddAsync(newBooking);
            await _context.SaveChangesAsync();
            return newBooking;
        }

        public async Task<Booking> UpdateBooking(Booking updatedBooking)
        {
            var existingBooking = await _context.Bookings.FindAsync(updatedBooking.Id);
            if (existingBooking == null)
            {
                return null; // Not found
            }

            _context.Entry(existingBooking).CurrentValues.SetValues(updatedBooking);
            await _context.SaveChangesAsync();
            return updatedBooking;
        }

        public async Task<bool> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return false; // Not found
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
