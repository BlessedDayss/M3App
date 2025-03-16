
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Newtonsoft.Json;
using NLog.Web;
using WebApplication1.ActionFilter;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

builder.Host.UseNLog();

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("❌ Database connection string is missing.");
}

builder.Services.AddDbContext<M3ManagmentContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None);
builder.Services.AddMemoryCache();
builder.Services.AddScoped<Cache>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
