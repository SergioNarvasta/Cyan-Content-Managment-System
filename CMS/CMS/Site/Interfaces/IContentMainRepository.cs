

using Site.Models;

namespace Site.Interfaces
{
    public interface IContentMainRepository
    {
        Task<IEnumerable<ContentMain>> GetByCompanyPk(string Company_Pk);
        Task<IEnumerable<ContentMain>> Listado();
    }
}
