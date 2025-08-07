using Domain.Interfaces;
using Infraestructure;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core - SQLite for development
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=bipass.db";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

// Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IConcertRepository, ConcertRepository>();

var app = builder.Build();

// Ensure database is created (development only) and seed initial data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();

    if (!await db.Users.AnyAsync())
    {
        db.Users.Add(new User { Name = "Usuario Demo", Email = "demo@bipass.com", Password = "123456" });
        await db.SaveChangesAsync();
    }

    if (!await db.Concerts.AnyAsync())
    {
        db.Concerts.Add(new Concert
        {
            Title = "Concierto Demo",
            Venue = "Teatro Central",
            City = "CABA",
            EventDateUtc = DateTime.UtcNow.AddDays(30),
            IsStreamingEnabled = true,
            StreamingUrl = "https://example.com/live/demo"
        });
        await db.SaveChangesAsync();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
