using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;


namespace CyanCMS.Application.Services
{
    public class TitleComponentAppService : ITitleComponentAppService
    {
        public readonly ITitleComponentService _titleComponentService;
        public TitleComponentAppService(ITitleComponentService titleComponentService) {
            _titleComponentService = titleComponentService;
        }
        public async Task Delete(string id)
        {
            await _titleComponentService.Delete(id);
        }

        public async Task<IEnumerable<TitleComponent>> GetAll()
        {
          return await _titleComponentService.GetAll();
        }

        public Task<TitleComponent> GetById(string id)
        {
            return _titleComponentService.GetById(id);
        }

        public async Task Insert(TitleComponent model)
        {
            await _titleComponentService.Insert(model);
        }

        public async Task Update(TitleComponent model)
        {
            await _titleComponentService.Update(model);
        }
    }
}
