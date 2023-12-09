using CyanCMS.Domain.Entities;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IComponentTypeService
    {
        Task<int> GetCountData();
        Task<bool> Insert(ComponentType model);
    }
}
