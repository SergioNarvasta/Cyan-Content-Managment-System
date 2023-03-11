
using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using CMS.Dominio.Interfaces.Servicios;

namespace CMS.Aplicacion.Servicios
{
    public class SliderMainAppService : ISliderMainAppService
    {
        private readonly ISliderMainService _contentMainService;

        public SliderMainAppService() { }
		public SliderMainAppService(ISliderMainService contentMainService) 
        {
          _contentMainService = contentMainService;
        }

        public Task DeleteSliderMain(string id)
        {
           return _contentMainService.DeleteSliderMain(id);
        }

        public Task<IEnumerable<SliderMain>> GetAllSliderMain()
        {
            return _contentMainService.GetAllSliderMain();
        }

        public Task InsertSliderMain(SliderMain sliderMain)
        {
           return _contentMainService.InsertSliderMain(sliderMain);
        }

        public Task UpdateSliderMain(SliderMain sliderMain)
        {
            return _contentMainService.UpdateSliderMain(sliderMain);
        }
    }
}
