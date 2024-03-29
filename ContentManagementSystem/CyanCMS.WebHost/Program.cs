using CyanCMS.Application.Interfaces;
using CyanCMS.Infraestructure.Data;
using CyanCMS.WebHost;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerLocalConnection"));
});

ConfigureServices.AddServices(builder.Services);

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
#region Config Project
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var rolAppService = services.GetRequiredService<IRolAppService>();

    await rolAppService.ConfigUserRolsInit();
}
#endregion 
app.Run();
