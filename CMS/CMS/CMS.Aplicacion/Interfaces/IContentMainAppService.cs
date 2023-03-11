using CMS.Dominio.Entidades;

namespace CMS.Aplicacion.Interfaces
{
    public interface IContentMainAppService
    {
        Task DeleteContentMain(string id);
        Task<IEnumerable<ContentMain>> GetAllContentMain();
        Task InsertContentMain(ContentMain contentmain);
        Task UpdateContentMain(ContentMain contentmain);
    }
}
