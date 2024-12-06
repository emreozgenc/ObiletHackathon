using ObiletHackathon.Api;
using ObiletHackathon.Api.Entities;
using ObiletHackathon.Api.Utilities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DatabaseConnectionFactory>();
builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/getPointList", (PointRequest request, IRepository repository) =>
{
    return repository.GetPoints(request);
})
.WithName("Points")
.WithOpenApi();

app.MapGet("/getJourneys", (JourneyRequest request, IRepository repository) =>
{
    return repository.GetJourneys(request);
})
.WithName("Journeys")
.WithOpenApi();
app.MapPost("/createReservation", (ReservationRequest request, IRepository repository) => { 

    var response = repository.CreateReservation(request);

    return response;
})
.WithName("CreateReservation")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
