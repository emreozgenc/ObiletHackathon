using Microsoft.AspNetCore.Mvc;
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
builder.Services.AddTransient<IRepository, JourneyRepository>();
builder.Configuration.AddUserSecrets("438a60c3-be47-4663-aca9-181338b586bd");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/getPointList", ([FromServices] IRepository repository) =>
{
    return repository.GetPoints(new PointRequest());
})
.WithName("Points")
.WithOpenApi();

app.MapPost("/getJourneys", ([FromBody] JourneyRequest request, [FromServices] IRepository repository) =>
{
    return repository.GetJourneys(request);
})
.WithName("Journeys")
.WithOpenApi();

app.MapPost("/createReservation", ([FromBody] ReservationRequest request, [FromServices] IRepository repository) => { 

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
