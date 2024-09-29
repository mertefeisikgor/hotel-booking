using HotelBooking.Models;
using HotelBooking.Data; // Make sure to include your data context
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Add this using directive for Task

namespace HotelBooking.Services
{
    public class PersonService : IPersonService
    {
        private readonly HotelBookingContext _context;

        public PersonService(HotelBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _context.Persons.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Person> CreatePerson(Person newPerson)
        {
            await _context.Persons.AddAsync(newPerson);
            await _context.SaveChangesAsync();
            return newPerson;
        }

        public async Task<Person> UpdatePerson(Person updatedPerson)
        {
            var existingPerson = await _context.Persons.FindAsync(updatedPerson.Id);
            if (existingPerson == null)
            {
                return null; // Not found
            }

            _context.Entry(existingPerson).CurrentValues.SetValues(updatedPerson);
            await _context.SaveChangesAsync();
            return updatedPerson;
        }

        public async Task<bool> DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return false; // Not found
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
