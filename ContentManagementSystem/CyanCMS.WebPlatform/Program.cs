using CyanCMS.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using CyanCMS.WebPlatform;
using CyanCMS.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerLocalConnection"));
});

ConfigureServices.AddServices(builder.Services);

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

#region Config Project
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var rolAppService = services.GetRequiredService<IRolAppService>();

    await rolAppService.ConfigUserRolsInit();
}
#endregion 

app.Run();
