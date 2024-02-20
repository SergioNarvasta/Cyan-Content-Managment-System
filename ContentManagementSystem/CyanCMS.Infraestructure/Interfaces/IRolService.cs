
using CyanCMS.Domain.Entities;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IRolService
    {
        Task<bool> Insert(Rol rol);
    }
}
