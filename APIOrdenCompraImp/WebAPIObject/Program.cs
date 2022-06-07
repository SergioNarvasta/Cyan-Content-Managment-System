using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPIObject.Data;
using WebAPIObject.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebAPIObjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebAPIObjectContext") ?? throw new InvalidOperationException("Connection string 'WebAPIObjectContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
