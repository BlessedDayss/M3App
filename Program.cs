
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Microsoft.OData.Edm;
using WebApplication1.Models;
using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);
string? connectionString;
if (builder.Environment.IsDevelopment())
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}
else
{
    connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("❌ Database connection string is missing.");
    }
}
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Database connection string is missing.");
}

builder.Services.AddDbContext<M3ManagmentContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None);  // System.Text.Json.Serialization.ReferenceHandler.Preserve)

// builder.Services.AddDbContext<M3ManagmentContext>(options =>
// {
//     options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDB"));
// });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.MapControllers();
app.Run();