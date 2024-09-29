using HotelBooking.Models;
using HotelBooking.Data; // Make sure to include your data context
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Add this using directive for Task

namespace HotelBooking.Services
{
    public class RoomService : IRoomService
    {
        private readonly HotelBookingContext _context;

        public RoomService(HotelBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Room> CreateRoom(Room newRoom)
        {
            await _context.Rooms.AddAsync(newRoom);
            await _context.SaveChangesAsync();
            return newRoom;
        }

        public async Task<Room> UpdateRoom(Room updatedRoom)
        {
            var existingRoom = await _context.Rooms.FindAsync(updatedRoom.Id);
            if (existingRoom == null)
            {
                return null; // Not found
            }

            _context.Entry(existingRoom).CurrentValues.SetValues(updatedRoom);
            await _context.SaveChangesAsync();
            return updatedRoom;
        }

        public async Task<bool> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return false; // Not found
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
