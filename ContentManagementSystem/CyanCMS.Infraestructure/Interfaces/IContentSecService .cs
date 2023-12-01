
using CyanCMS.Domain.Entities;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IContentSecService
    {
        Task Delete(string id);
        Task<IEnumerable<ContentSec>> GetAll();
		Task<ContentSec> GetById(string id);
		Task Insert(ContentSec sliderMain);
        Task Update(ContentSec sliderMain);
    }
}
