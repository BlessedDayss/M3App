using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
.AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);



// builder.Services.AddDbContext<M3ManagmentContext>(options =>
// {
//     options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDB"));
// });

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection();
app.MapControllers();
app.Run();