using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;


namespace CyanCMS.Application.Services
{
    public class AsideAppService : IAsideAppService
    {
        public readonly IAsideService _asideService;
        public AsideAppService(IAsideService asideService) {
            _asideService = asideService;
        }
        public async Task Delete(string id)
        {
            await _asideService.Delete(id);
        }

        public async Task<IEnumerable<Aside>> GetAll()
        {
          return await _asideService.GetAll();
        }

        public Task<Aside> GetById(string id)
        {
            return _asideService.GetById(id);
        }

        public async Task Insert(Aside model)
        {
            await _asideService.Insert(model);
        }

        public async Task Update(Aside model)
        {
            await _asideService.Update(model);
        }
    }
}
