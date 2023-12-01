using CyanCMS.Domain.Entities

namespace CyanCMS.Application.Interfaces
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
