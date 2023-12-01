using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;


namespace CyanCMS.Application.Services
{
    public class ContentSecAppService : IContentSecAppService
    {
        public readonly IContentSecService _contentSecService;
        public ContentSecAppService(IContentSecService contentSecService) {
            _contentSecService = contentSecService;
        }
        public async Task Delete(string id)
        {
            await _contentSecService.Delete(id);
        }

        public async Task<IEnumerable<ContentSec>> GetAll()
        {
          return await _contentSecService.GetAll();
        }

        public Task<ContentSec> GetById(string id)
        {
            return _contentSecService.GetById(id);
        }

        public async Task Insert(ContentSec model)
        {
            await _contentSecService.Insert(model);
        }

        public async Task Update(ContentSec model)
        {
            await _contentSecService.Update(model);
        }
    }
}
