using CyanCMS.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using CyanCMS.Application.Interfaces;
using CyanCMS.Application.Services;
using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Infraestructure.Services;
using CMS.Infraestructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerLocalConnection"));
});

builder.Services.AddTransient<IUserAppService, UserAppService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ISessionAppService, SessionAppService>();
builder.Services.AddTransient<ISessionService, SessionService>();
builder.Services.AddTransient<ICompanyAppService, CompanyAppService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();

builder.Services.AddTransient<IConfigurationAppService, ConfigurationAppService>();
builder.Services.AddTransient<IConfigurationService, ConfigurationService>();
builder.Services.AddTransient<IConfigurationComponentTypeAppService, ConfigurationComponentTypeAppService>();
builder.Services.AddTransient<IConfigurationComponentTypeService, ConfigurationComponentTypeService>();
builder.Services.AddTransient<IComponentAppService, ComponentAppService>();
builder.Services.AddTransient<IComponentService, ComponentService>();
builder.Services.AddTransient<IComponentTypeAppService, ComponentTypeAppService>();
builder.Services.AddTransient<IComponentTypeService, ComponentTypeService>();
builder.Services.AddTransient<IFileAppService, FileAppService>();
builder.Services.AddTransient<IFileService, FileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Identity}/{action=Login}/{id?}");

app.Run();
