using CMS.Dominio.Entidades;
using CMS.Dominio.Interfaces.Repositorios;
using CMS.Dominio.Interfaces.Servicios;

namespace CMS.Dominio.Servicios
{
    public class SliderMainService : ISliderMainService
    {
        private readonly ISliderMainRepository _repository;
        public SliderMainService(ISliderMainRepository repository) 
        {
            _repository = repository;
        }

        public Task DeleteSliderMain(string id)
        {
            return _repository.DeleteSliderMain(id);
        }

        public Task<IEnumerable<SliderMain>> GetAllSliderMain()
        {
            return _repository.GetAllSliderMain();
        }

        public Task InsertSliderMain(SliderMain sliderMain)
        {
            return _repository.InsertSliderMain(sliderMain);
        }

        public Task UpdateSliderMain(SliderMain sliderMain)
        {
            return _repository.UpdateSliderMain(sliderMain);
        }
    }
}
