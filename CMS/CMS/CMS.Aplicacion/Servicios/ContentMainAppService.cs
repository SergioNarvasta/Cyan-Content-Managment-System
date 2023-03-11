using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using CMS.Dominio.Interfaces;

namespace CMS.Aplicacion.Servicios
{
    public class ContentMainAppService : IContentMainAppService
    {
        private readonly IContentMainService _contentMainService;

        public ContentMainAppService(IContentMainService contentMainService) 
        {
          _contentMainService = contentMainService;
        }

        public Task DeleteContentMain(string id)
        {
           return _contentMainService.DeleteContentMain(id);
        }

        public Task<IEnumerable<ContentMain>> GetAllContentMain()
        {
            return _contentMainService.GetAllContentMain();
        }

        public Task InsertContentMain(ContentMain contentmain)
        {
           return _contentMainService.InsertContentMain(contentmain);
        }

        public Task UpdateContentMain(ContentMain contentmain)
        {
            return _contentMainService.UpdateContentMain(contentmain);
        }
    }
}
