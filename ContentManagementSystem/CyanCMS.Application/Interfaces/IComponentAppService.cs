using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;

namespace CyanCMS.Application.Interfaces
{
    public interface IComponentAppService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Component>> GetAll(ComponentParams @params);
        Task<Component> GetById(int ComponentId);
        Task<CreateModel> Insert(Component model);
        Task<bool> Update(Component model);
    }
}
