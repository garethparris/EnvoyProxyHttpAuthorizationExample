using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

const string BasicAuth = "Basic";
Encoding encoding = Encoding.GetEncoding("iso-8859-1");

app.MapGet("/authz", async (context) => {

    string? authHeader = context.Request.Headers["Authorization"];

    if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith(BasicAuth))
    {
        var decodedBase64 = Convert.FromBase64String(authHeader[BasicAuth.Length..].Trim());
        var usernamePassword = encoding.GetString(decodedBase64).Split(':');

        var username = usernamePassword[0];
        var password = usernamePassword[1];

        if (username == "gareth" && password == "pa55w0rd")
        {
            context.Response.Headers.Add("x-current-user", username);
            
            context.Response.StatusCode = 200;
            return;
        }
    }

    context.Response.StatusCode = 401;
    await context.Response.WriteAsync("Unauthorized");
});

app.Run();
