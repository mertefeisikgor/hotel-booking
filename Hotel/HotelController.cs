using HotelBooking.Models;
using HotelBooking.Services; // Ensure you include the namespace for IHotelService
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks; // Include for Task

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService; // Use the service interface

        public HotelController(IHotelService hotelService) // Inject the service
        {
            _hotelService = hotelService;
        }

        // GET: api/hotel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetAllHotels() // Use async
        {
            var hotels = await _hotelService.GetAllHotels(); // Call the service method
            return Ok(hotels);
        }

        // GET: api/hotel/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotelById(int id) // Use async
        {
            var hotel = await _hotelService.GetHotelById(id); // Call the service method

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        // POST: api/hotel
        [HttpPost]
        public async Task<ActionResult<Hotel>> CreateHotel([FromBody] Hotel newHotel) // Use async
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdHotel = await _hotelService.CreateHotel(newHotel); // Call the service method

            return CreatedAtAction(nameof(GetHotelById), new { id = createdHotel.Id }, createdHotel);
        }

        // PUT: api/hotel/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHotel(int id, [FromBody] Hotel updatedHotel) // Use async
        {

            System.Console.WriteLine(id);



            if (id != updatedHotel.Id)
            {
                return BadRequest();
            }

            var existingHotel = await _hotelService.UpdateHotel(updatedHotel); // Call the service method
            if (existingHotel == null)
            {
                return NotFound();
            }

            return NoContent(); // 204 No Content
        }

        // DELETE: api/hotel/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHotel(int id) // Use async
        {
            var deleted = await _hotelService.DeleteHotel(id); // Call the service method
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
