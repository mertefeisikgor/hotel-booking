using HotelBooking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookings(); // Async method
        Task<Booking> GetBookingById(int id); // Async method
        Task<Booking> CreateBooking(Booking newBooking); // Async method
        Task<Booking> UpdateBooking(Booking updatedBooking); // Async method
        Task<bool> DeleteBooking(int id); // Keep this as returning Task<bool>
    }
}
