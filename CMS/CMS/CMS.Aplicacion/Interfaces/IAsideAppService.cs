using CMS.Dominio.Entidades;

namespace CMS.Aplicacion.Interfaces
{
    public interface IAsideAppService
    {
        Task Delete(string id);
        Task<IEnumerable<Aside>> GetAll();
		Task<Aside> GetById(string id);
		Task Insert(Aside model);
        Task Update(Aside model);
    }
}
