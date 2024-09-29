using HotelBooking.Models;
using Microsoft.Extensions.Hosting; // Import for IHostEnvironment
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBooking.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotelBookingContext context, IHostEnvironment env)
        {
            // Only clear and seed the database in the development environment
            if (env.IsDevelopment())
            {
                using var transaction = context.Database.BeginTransaction();
                try
                {
                    // Remove existing data
                    context.Hotels.RemoveRange(context.Hotels);
                    context.Bookings.RemoveRange(context.Bookings);
                    context.Rooms.RemoveRange(context.Rooms);
                    context.Persons.RemoveRange(context.Persons);
                    context.SaveChanges();

                    // Seed data
                    var hotels = new List<Hotel>
                    {
                        new Hotel { Name = "Hotel A", Location = "City A", Rating = 5 },
                        new Hotel { Name = "Hotel B", Location = "City B", Rating = 4 }
                    };

                    context.Hotels.AddRange(hotels);
                    context.SaveChanges(); // Save hotels first to get IDs

                    var rooms = new List<Room>
                    {
                        new Room { Floor = "1", SquareMeter = 22, QualityRating = 5, HotelId = hotels[0].Id },
                        new Room { Floor = "2", SquareMeter = 19, QualityRating = 3, HotelId = hotels[1].Id },
                    };

                    context.Rooms.AddRange(rooms);
                    context.SaveChanges(); // Save rooms to get IDs

                    var persons = new List<Person>
                    {
                        new Person { FirstName = "Mert Efe", LastName = "Isikgor", PhoneNumber = "+0905538151095", BirthDate = new DateTime(1995, 6, 10, 0, 0, 0, DateTimeKind.Utc) },
                        new Person { FirstName = "Efe Mert", LastName = "Isikgor", PhoneNumber = "+0905538151095", BirthDate = new DateTime(1995, 6, 10, 0, 0, 0, DateTimeKind.Utc) },
                    };

                    context.Persons.AddRange(persons);
                    context.SaveChanges(); // Save persons to get IDs

                    // Use UTC dates for bookings
                    var bookings = new List<Booking>
                    {
                        new Booking
                        {
                            StartDate = DateTime.UtcNow, // Use current UTC time for booking start
                            EndDate = DateTime.UtcNow.AddDays(1), // Example: booking for 1 day
                            RoomId = rooms[0].Id,
                            PersonId = persons[0].Id,
                            PersonComments = "This room needs more heat",
                            CleanUpRequestedCount = 0 // Set to 0 if default is required
                        },
                    };

                    context.Bookings.AddRange(bookings);
                    context.SaveChanges();

                    transaction.Commit(); // Commit the transaction
                }
                catch
                {
                    transaction.Rollback(); // Roll back the transaction in case of an error
                    throw; // Rethrow the error after rolling back
                }
            }
        }
    }
}
