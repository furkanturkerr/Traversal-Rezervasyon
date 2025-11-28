using Microsoft.EntityFrameworkCore;
using SıgnalRApi.Dal;
using SıgnalRApi.Hubs;
using SıgnalRApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Servisler ekleniyor
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

// CORS Ayarı: Her yerden gelen isteğe izin ver
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true) 
            .AllowCredentials();
    }));

builder.Services.AddControllers();
builder.Services.AddScoped<VisitorService>();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// *** DİKKAT: Bu satırı sildik/yorum yaptık. Artık HTTP'yi HTTPS'e zorlamayacak. ***
// app.UseHttpsRedirection(); 

// CORS Middleware'i
app.UseCors("CorsPolicy");

app.MapControllers();
app.MapHub<VisitorHub>("/VisitorHub");

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

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}