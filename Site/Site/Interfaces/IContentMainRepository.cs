

using Site.Models;

namespace Site.Interfaces
{
    public interface IContentMainRepository
    {
        Task<IEnumerable<ContentMain>> Listado();
    }
}
