using CyanCMS.Application.Interfaces;
using CyanCMS.Application.Services;
using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Infraestructure.Services;

namespace CyanCMS.WebHost
{
    public class ConfigureServices
    {
        public static void AddServices(IServiceCollection services)
        {

            services.AddTransient<ICompanyAppService, CompanyAppService>();
            services.AddTransient<ICompanyService, CompanyService>();

            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IConfigurationAppService, ConfigurationAppService>();
            services.AddTransient<IConfigurationService, ConfigurationService>();

            services.AddTransient<IConfigurationComponentTypeAppService, ConfigurationComponentTypeAppService>();
            services.AddTransient<IConfigurationComponentTypeService, ConfigurationComponentTypeService>();

            services.AddTransient<IComponentTypeAppService, ComponentTypeAppService>();
            services.AddTransient<IComponentTypeService, ComponentTypeService>();

            services.AddTransient<IComponentAppService, ComponentAppService>();
            services.AddTransient<IComponentService, ComponentService>();
        }
    }
}
