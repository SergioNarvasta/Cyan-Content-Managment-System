using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Utils.Response;


namespace CyanCMS.Application.Services
{
    public class ConfigurationAppService : IConfigurationAppService
    {
        public readonly IConfigurationService _configurationService;
        public ConfigurationAppService(IConfigurationService configurationService) {
            _configurationService = configurationService;
        }
        public async Task<List<Configuration>> GetByCompanyId(int companyId)
        {
            return await _configurationService.GetByCompanyId(companyId);
        }
        public async Task<Configuration> GetById(string id)
        {
            return await _configurationService.GetById(id);
        }
        public async Task<int> GetCountByCompany(int companyId)
        {
            return await _configurationService.GetCountByCompany(companyId);
        }
        public async Task<CreateModel> Insert(Configuration model)
        {
            int countByCompany = await this.GetCountByCompany(model.CompanyId);
            if (countByCompany == 0) {
                return await _configurationService.Insert(model);
            }
            return false;
        }
        public async Task<bool> Update(Configuration model)
        {
            return await _configurationService.Update(model);
        }
    }
}
