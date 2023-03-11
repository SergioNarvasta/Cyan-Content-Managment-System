using CMS.Dominio.Entidades;
using CMS.Dominio.Interfaces.Repositorios;
using CMS.Dominio.Interfaces.Servicios;

namespace CMS.Dominio.Servicios
{
    public class ContentMainService : IContentMainService
    {
        private readonly IContentMainRepository _repository;
        public ContentMainService(IContentMainRepository repository) 
        {
            _repository = repository;
        }

        public Task DeleteContentMain(string id)
        {
            return _repository.DeleteContentMain(id);
        }

        public Task<IEnumerable<ContentMain>> GetAllContentMain()
        {
            return _repository.GetAllContentMain();
        }

        public Task InsertContentMain(ContentMain contentmain)
        {
            return _repository.InsertContentMain(contentmain);
        }

        public Task UpdateContentMain(ContentMain contentmain)
        {
            return _repository.UpdateContentMain(contentmain);
        }
    }
}
