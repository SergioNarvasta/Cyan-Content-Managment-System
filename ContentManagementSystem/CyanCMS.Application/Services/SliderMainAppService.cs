using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;


namespace CyanCMS.Application.Services
{
    public class SliderMainAppService : ISliderMainAppService
    {
        public readonly ISliderMainService _sliderMainService;
        public SliderMainAppService(ISliderMainService sliderMainService) {
            _sliderMainService = sliderMainService;
        }
        public async Task Delete(string id)
        {
            await _sliderMainService.Delete(id);
        }

        public async Task<IEnumerable<SliderMain>> GetAll()
        {
          return await _sliderMainService.GetAll();
        }

        public Task<SliderMain> GetById(string id)
        {
            return _sliderMainService.GetById(id);
        }

        public async Task Insert(SliderMain model)
        {
            await _sliderMainService.Insert(model);
        }

        public async Task Update(SliderMain model)
        {
            await _sliderMainService.Update(model);
        }
    }
}
