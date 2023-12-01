using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;


namespace CyanCMS.Application.Services
{
    public class ContentMainAppService : IContentMainAppService
    {
        public readonly IContentMainService _contentMainService;
        public ContentMainAppService(IContentMainService contentMainService) {
            _contentMainService = contentMainService;
        }
        public async Task Delete(string id)
        {
            await _contentMainService.Delete(id);
        }

        public async Task<IEnumerable<ContentMain>> GetAll()
        {
            return await _contentMainService.GetAll();
        }

        public Task<ContentMain> GetById(string id)
        {
            return _contentMainService.GetById(id);
        }

        public async Task Insert(ContentMain model)
        {
            await _contentMainService.Insert(model);
        }

        public async Task Update(ContentMain model)
        {
            await _contentMainService.Update(model);
        }
    }
}
