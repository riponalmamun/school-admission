using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Data;

var builder = WebApplication.CreateBuilder(args);

// Database connection environment variable theke ashbe (assignment-er niyom)
var connectionString = builder.Configuration["DB_CONNECTION"]
    ?? "Host=localhost;Port=5432;Database=school_admission;Username=postgres;Password=postgres";

builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(connectionString));

var app = builder.Build();

// Table toiri kora. Docker-e Postgres ektu deri-te chalu hole abar chesta korbe
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    for (var i = 0; i < 15; i++)
    {
        try { db.Database.EnsureCreated(); break; }
        catch when (i < 14) { Thread.Sleep(2000); }
    }
}

app.MapGet("/", () => "School Admission API is running");

app.Run();