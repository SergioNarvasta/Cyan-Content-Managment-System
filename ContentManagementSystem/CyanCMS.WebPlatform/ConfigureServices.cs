
using CyanCMS.Application.Interfaces;
using CyanCMS.Application.Services;
using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Infraestructure.Services;

namespace CyanCMS.WebPlatform
{
    public class ConfigureServices
    {
        public static void AddServices(IServiceCollection services)
        {

            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISessionAppService, SessionAppService>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<IRolAppService, RolAppService>();
            services.AddTransient<IRolService, RolService>();
            // services.AddTransient<IPlanAppService, PlanAppService>();
            // services.AddTransient<IPlanService, PlanService>();

            services.AddTransient<ICompanyAppService, CompanyAppService>();
            services.AddTransient<ICompanyService, CompanyService>();
            
            services.AddTransient<IConfigurationAppService, ConfigurationAppService>();
            services.AddTransient<IConfigurationService, ConfigurationService>();
            services.AddTransient<IConfigurationComponentTypeAppService, ConfigurationComponentTypeAppService>();
            services.AddTransient<IConfigurationComponentTypeService, ConfigurationComponentTypeService>();
            services.AddTransient<IComponentAppService, ComponentAppService>();
            services.AddTransient<IComponentService, ComponentService>();
            services.AddTransient<IComponentTypeAppService, ComponentTypeAppService>();
            services.AddTransient<IComponentTypeService, ComponentTypeService>();
            services.AddTransient<IFileAppService, FileAppService>();
            services.AddTransient<IFileService, FileService>();
        }
    }
}
