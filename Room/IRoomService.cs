using HotelBooking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRooms(); // Async method
        Task<Room> GetRoomById(int id); // Async method
        Task<Room> CreateRoom(Room newRoom); // Async method
        Task<Room> UpdateRoom(Room updatedRoom); // Async method
        Task<bool> DeleteRoom(int id); // Keep this as returning Task<bool>
    }
}
