


using CyanCMS.Domain.Entities;

namespace CyanCMS.Application.Interfaces
{
    public interface IConfigurationComponentTypeAppService
    {
        Task<bool> CreateConfigComponentTypeInit(int configurationId);
        Task<bool> Insert(ConfigurationComponentType model);
    }
}
