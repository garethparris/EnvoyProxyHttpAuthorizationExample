var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

string instanceId = Guid.NewGuid().ToString();

var names = new[]
{
    "Ford Capri", "Kia Sportage", "Lamborghini Diablo", "Ferrari SF90XX", "Ford Explorer", "Hyundai Tucson", "Jaguar i-Pace"
};

app.MapGet("/id", () =>
{
    return $"Car Service Instance ID: {instanceId}";
});

app.MapGet("/random", () =>
{
    return names[Random.Shared.Next(names.Length)];
});

app.Run();

