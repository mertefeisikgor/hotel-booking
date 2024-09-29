using HotelBooking.Models;
using HotelBooking.Data; // Make sure to include your data context
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Add this using directive for Task

namespace HotelBooking.Services
{
    public class HotelService : IHotelService
    {
        private readonly HotelBookingContext _context;

        public HotelService(HotelBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Hotel> CreateHotel(Hotel newHotel)
        {
            await _context.Hotels.AddAsync(newHotel);
            await _context.SaveChangesAsync();
            return newHotel;
        }

        public async Task<Hotel> UpdateHotel(Hotel updatedHotel)
        {
            var existingHotel = await _context.Hotels.FindAsync(updatedHotel.Id);
            if (existingHotel == null)
            {
                return null; // Not found
            }

            _context.Entry(existingHotel).CurrentValues.SetValues(updatedHotel);
            await _context.SaveChangesAsync();
            return updatedHotel;
        }

        public async Task<bool> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return false; // Not found
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
