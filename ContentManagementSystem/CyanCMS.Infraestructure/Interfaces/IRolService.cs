
using CyanCMS.Domain.Entities;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IRolService
    {
        Task<int> CountAsync();
        Task<Rol> FindByName(string name);
        Task<bool> Insert(Rol rol);
    }
}
