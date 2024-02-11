using CyanCMS.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using CyanCMS.Application.Interfaces;
using CyanCMS.Application.Services;
using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Infraestructure.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerLocalConnection"));
});

builder.Services.AddTransient<ICompanyAppService, CompanyAppService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();

builder.Services.AddTransient<IUserAppService, UserAppService>();
builder.Services.AddTransient<IUserService, UserService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
