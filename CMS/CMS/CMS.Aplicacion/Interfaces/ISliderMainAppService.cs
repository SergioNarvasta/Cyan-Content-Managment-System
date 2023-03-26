using CMS.Dominio.Entidades;

namespace CMS.Aplicacion.Interfaces
{
    public interface ISliderMainAppService
    {
        Task Delete(string id);
        Task<IEnumerable<SliderMain>> GetAll();
		Task<SliderMain> GetById(string id);
		Task Insert(SliderMain sliderMain);
        Task Update(SliderMain sliderMain);
    }
}
