using ObiletHackathon.Api;
using ObiletHackathon.Api.Utilities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DatabaseConnectionFactory>();
builder.Configuration.AddUserSecrets("438a60c3-be47-4663-aca9-181338b586bd");
builder.Services.AddSingleton<IRepository, JourneyRepository>();
builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



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
