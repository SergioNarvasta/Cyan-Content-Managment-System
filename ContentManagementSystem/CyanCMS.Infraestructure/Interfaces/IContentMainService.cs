using CMS.Dominio.Entidades;
using CyanCMS.Domain.Entities;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IContentMainService
    {
        Task Delete(string id);
        Task<IEnumerable<ContentMain>> GetAll();
		Task<ContentMain> GetById(string id);
		Task Insert(ContentMain model);
        Task Update(ContentMain model);
    }
}
