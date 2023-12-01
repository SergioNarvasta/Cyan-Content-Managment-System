using CMS.Dominio.Entidades;
using CyanCMS.Domain.Entities;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IAsideService
    {
        Task Delete(string id);
        Task<IEnumerable<Aside>> GetAll();
		Task<Aside> GetById(string id);
		Task Insert(Aside model);
        Task Update(Aside model);
    }
}
