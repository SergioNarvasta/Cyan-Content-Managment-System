
using CyanCMS.Infraestructure.Data;
using CyanCMS.Application.Interfaces;
using CyanCMS.Application.Services;
using CyanCMS.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using CyanCMS.Infraestructure.Services;

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

builder.Services.AddTransient<IPartnerAppService, PartnerAppService>();
builder.Services.AddTransient<IPartnerService, PartnerService>();

builder.Services.AddTransient<ISliderMainAppService, SliderMainAppService>();
builder.Services.AddTransient<ISliderMainService, SliderMainService>();

builder.Services.AddTransient<ITitleComponentAppService, TitleComponentAppService>();
builder.Services.AddTransient<ITitleComponentService, TitleComponentService>();

builder.Services.AddTransient<IUserAppService, UserAppService>();
builder.Services.AddTransient<IUserService, UserService>();

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
