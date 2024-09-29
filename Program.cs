using HotelBooking.Data;
using HotelBooking.Services; // Ensure this namespace is included for services
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext with PostgreSQL connection
builder.Services.AddDbContext<HotelBookingContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the BookingService and IBookingService for dependency injection
builder.Services.AddScoped<IBookingService, BookingService>();

// Register the HotelService and IHotelService for dependency injection
builder.Services.AddScoped<IHotelService, HotelService>();

// Register the RoomService and IRoomServiceService for dependency injection
builder.Services.AddScoped<IRoomService, RoomService>();

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Seed database if the configuration allows it
var seedDatabase = builder.Configuration["SeedDatabase"];

if (seedDatabase?.ToLower() == "true")
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<HotelBookingContext>(); // Use HotelBookingContext
        var env = services.GetRequiredService<IHostEnvironment>(); // Get the environment

        DbInitializer.Initialize(context, env); // Initialize the database
    }
}

app.Run();
