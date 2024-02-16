using CMS.Dominio.Entidades;
using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Request;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IUserService
    {
        Task<bool> Delete(string id);
        Task<IEnumerable<User>> GetAll(UserParams @params);
        Task<User> GetById(int id);
        Task<bool> Insert(User user);
        Task<bool> Update(User user);
    }
}
