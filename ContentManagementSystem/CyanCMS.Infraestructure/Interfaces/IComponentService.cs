

using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IComponentService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Component>> GetAll(ComponentParams @params);
        Task<Component> GetById(int id);
        Task<CreateModel> Insert(Component model);
        Task<bool> Update(Component model);
    }
}
