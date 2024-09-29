using HotelBooking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPersons(); // Async method
        Task<Person> GetPersonById(int id); // Async method
        Task<Person> CreatePerson(Person newPerson); // Async method
        Task<Person> UpdatePerson(Person updatedPerson); // Async method
        Task<bool> DeletePerson(int id); // Keep this as returning Task<bool>
    }
}
