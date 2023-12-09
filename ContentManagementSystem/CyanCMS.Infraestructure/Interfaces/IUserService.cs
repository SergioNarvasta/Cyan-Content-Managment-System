using CMS.Dominio.Entidades;
using CyanCMS.Domain.Entities;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IUserService
    {
        Task<bool> Delete(string id);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string id);
        Task<bool> Insert(User user);
        Task<bool> Update(User user);
    }
}
