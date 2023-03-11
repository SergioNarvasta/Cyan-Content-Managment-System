using CMS.Dominio.Entidades;

namespace CMS.Aplicacion.Interfaces
{
    public interface ISliderMainAppService
    {
        Task DeleteSliderMain(string id);
        Task<IEnumerable<SliderMain>> GetAllSliderMain();
        Task InsertSliderMain(SliderMain sliderMain);
        Task UpdateSliderMain(SliderMain sliderMain);
    }
}
