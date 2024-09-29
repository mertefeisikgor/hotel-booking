using HotelBooking.Models;
using HotelBooking.Services; // Ensure you include the namespace for IPersonService
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks; // Include for Task

namespace PersonBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService; // Use the service interface

        public PersonController(IPersonService personService) // Inject the service
        {
            _personService = personService;
        }

        // GET: api/person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPersons() // Use async
        {
            var persons = await _personService.GetAllPersons(); // Call the service method
            return Ok(persons);
        }

        // GET: api/person/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonById(int id) // Use async
        {
            var person = await _personService.GetPersonById(id); // Call the service method

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // POST: api/person
        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson([FromBody] Person newPerson) // Use async
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPerson = await _personService.CreatePerson(newPerson); // Call the service method

            return CreatedAtAction(nameof(GetPersonById), new { id = createdPerson.Id }, createdPerson);
        }

        // PUT: api/person/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePerson(int id, [FromBody] Person updatedPerson) // Use async
        {
            if (id != updatedPerson.Id)
            {
                return BadRequest();
            }

            var existingPerson = await _personService.UpdatePerson(updatedPerson); // Call the service method
            if (existingPerson == null)
            {
                return NotFound();
            }

            return NoContent(); // 204 No Content
        }

        // DELETE: api/person/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id) // Use async
        {
            var deleted = await _personService.DeletePerson(id); // Call the service method
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
