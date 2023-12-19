using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;

namespace CyanCMS.Application.Services
{
    public class ConfigurationComponentTypeAppService : IConfigurationComponentTypeAppService
    {
        private readonly IConfigurationComponentTypeService _configurationComponentTypeService;
        private readonly IComponentTypeService _componentTypeService;
        public ConfigurationComponentTypeAppService(IConfigurationComponentTypeService configurationComponentTypeService, IComponentTypeService componentTypeService) {
           _configurationComponentTypeService = configurationComponentTypeService;
            _componentTypeService = componentTypeService;
        }

        public async Task<bool> Insert(ConfigurationComponentType model)
        {
            return await _configurationComponentTypeService.Insert(model);
        }

        public async Task<bool> CreateConfigComponentTypeInit(int configurationId) {
            var listComponentType = await _componentTypeService.GetAll();
            bool isActive = false;
            bool isDeleted = false;
            var response = false;
            foreach (var component in listComponentType)
            {
                var configComponentType = new ConfigurationComponentType()
                {
                    ComponentTypeId = component.ComponentTypeId,
                    ConfigurationId = configurationId,
                    IsActive = isActive,
                    IsDeleted = isDeleted
                };
                response = await this.Insert(configComponentType); 
            }
            return response;
        }
    }
}
