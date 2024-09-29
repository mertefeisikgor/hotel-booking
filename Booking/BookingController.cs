using HotelBooking.Models;
using HotelBooking.Services; // Ensure you include the namespace for IBookingService
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks; // Include for Task

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService; // Use the service interface

        public BookingController(IBookingService bookingService) // Inject the service
        {
            _bookingService = bookingService;
        }

        // GET: api/booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAllBookings() // Use async
        {
            var bookings = await _bookingService.GetAllBookings(); // Call the service method
            return Ok(bookings);
        }

        // GET: api/booking/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBookingById(int id) // Use async
        {
            var booking = await _bookingService.GetBookingById(id); // Call the service method

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // POST: api/booking
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking([FromBody] Booking newBooking) // Use async
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBooking = await _bookingService.CreateBooking(newBooking); // Call the service method

            return CreatedAtAction(nameof(GetBookingById), new { id = createdBooking.Id }, createdBooking);
        }

        // PUT: api/booking/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBooking(int id, [FromBody] Booking updatedBooking) // Use async
        {
            if (id != updatedBooking.Id)
            {
                return BadRequest();
            }

            var existingBooking = await _bookingService.UpdateBooking(updatedBooking); // Call the service method
            if (existingBooking == null)
            {
                return NotFound();
            }

            return NoContent(); // 204 No Content
        }

        // DELETE: api/booking/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBooking(int id) // Use async
        {
            var deleted = await _bookingService.DeleteBooking(id); // Call the service method
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
