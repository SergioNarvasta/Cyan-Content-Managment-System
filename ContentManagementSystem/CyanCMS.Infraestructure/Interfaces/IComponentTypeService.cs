using CyanCMS.Domain.Entities;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IComponentTypeService
    {
        Task<List<ComponentType>> GetAll();
        Task<int> GetCountData();
        Task<bool> Insert(ComponentType model);
    }
}
