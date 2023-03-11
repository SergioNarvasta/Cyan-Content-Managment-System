using CMS.Dominio.Entidades;

namespace CMS.Dominio.Interfaces.Servicios
{
    public interface ISliderMainService
    {
        Task DeleteSliderMain(string id);
        Task<IEnumerable<SliderMain>> GetAllSliderMain();
        Task InsertSliderMain(SliderMain sliderMain);
        Task UpdateSliderMain(SliderMain sliderMain);
    }
}
