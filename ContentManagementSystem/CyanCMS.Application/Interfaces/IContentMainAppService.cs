using CyanCMS.Domain.Entities

namespace CyanCMS.Application.Interfaces
{
    public interface IContentMainAppService
    {
        Task Delete(string id);
        Task<IEnumerable<ContentMain>> GetAll();
		Task<ContentMain> GetById(string id);
		Task Insert(ContentMain model);
        Task Update(ContentMain model);
    }
}
