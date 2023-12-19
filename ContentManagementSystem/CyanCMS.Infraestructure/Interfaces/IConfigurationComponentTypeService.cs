

using CyanCMS.Domain.Entities;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IConfigurationComponentTypeService
    {
        Task<bool> Insert(ConfigurationComponentType model);
    }
}
