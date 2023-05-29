using CMS.Aplicacion.Interfaces;
using CMS.Infraestructura.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ISliderMainAppService,SliderMainCollection>();
builder.Services.AddTransient<IUserAppService, UserCollection>();
builder.Services.AddTransient<ISessionAppService,SessionRepository>();
builder.Services.AddTransient<ICompanyAppService, CompanyCollection>();
builder.Services.AddTransient<IContentMainAppService, ContentMainCollection>();
builder.Services.AddTransient<IContentSecAppService, ContentSecCollection>();
builder.Services.AddTransient<IAsideAppService, AsideCollection>();
builder.Services.AddTransient<ITitleComponentService,TitleComponentCollection>();   
builder.Services.AddTransient<IPartnerAppService,PartnerCollection>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
