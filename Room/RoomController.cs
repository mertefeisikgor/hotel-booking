using HotelBooking.Models;
using HotelBooking.Services; // Ensure you include the namespace for IRoomService
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks; // Include for Task

namespace RoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService; // Use the service interface

        public RoomController(IRoomService roomService) // Inject the service
        {
            _roomService = roomService;
        }

        // GET: api/room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRooms() // Use async
        {
            var rooms = await _roomService.GetAllRooms(); // Call the service method
            return Ok(rooms);
        }

        // GET: api/room/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomById(int id) // Use async
        {
            var room = await _roomService.GetRoomById(id); // Call the service method

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // POST: api/room
        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoom([FromBody] Room newRoom) // Use async
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdRoom = await _roomService.CreateRoom(newRoom); // Call the service method

            return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.Id }, createdRoom);
        }

        // PUT: api/room/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoom(int id, [FromBody] Room updatedRoom) // Use async
        {
            if (id != updatedRoom.Id)
            {
                return BadRequest();
            }

            var existingRoom = await _roomService.UpdateRoom(updatedRoom); // Call the service method
            if (existingRoom == null)
            {
                return NotFound();
            }

            return NoContent(); // 204 No Content
        }

        // DELETE: api/room/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoom(int id) // Use async
        {
            var deleted = await _roomService.DeleteRoom(id); // Call the service method
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
