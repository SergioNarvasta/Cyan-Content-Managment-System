using CMS.Infraestructura.Services;
using CMS.Infraestructure.Data;
using CyanCMS.Application.Interfaces;
using CyanCMS.Application.Services;
using CyanCMS.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SmartCMS.Infraestructure.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSQLDatabaseConnection"));
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CyanCMS_WebAPI", Version = "v1" });
    c.CustomSchemaIds(x => x.FullName); 
});

builder.Services.AddTransient<IAsideAppService, AsideAppService>();
builder.Services.AddTransient<IAsideService, AsideService>();

builder.Services.AddTransient<ICompanyAppService, CompanyAppService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();

builder.Services.AddTransient<IContentMainAppService, ContentMainAppService>();
builder.Services.AddTransient<IContentMainService, ContentMainService>();

builder.Services.AddTransient<IContentSecAppService, ContentSecAppService>();
builder.Services.AddTransient<IContentSecService, ContentSecService>();

builder.Services.AddTransient<IContentSecService, ContentSecService>();

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
