using HotelBooking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetAllHotels(); // Async method
        Task<Hotel> GetHotelById(int id); // Async method
        Task<Hotel> CreateHotel(Hotel newHotel); // Async method
        Task<Hotel> UpdateHotel(Hotel updatedHotel); // Async method
        Task<bool> DeleteHotel(int id); // Keep this as returning Task<bool>
    }
}
