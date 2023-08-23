var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

string instanceId = Guid.NewGuid().ToString();

var names = new[]
{
    "Gareth", "John", "David", "Simon", "Fred", "Thomas", "James", "Henry"
};

app.MapGet("/id", () =>
{
    return $"Person Service Instance ID: {instanceId}";
});

app.MapGet("/random", () =>
{
    return names[Random.Shared.Next(names.Length)];
});

app.Run();


