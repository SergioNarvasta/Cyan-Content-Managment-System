using CMS.Dominio.Entidades;
using CyanCMS.Domain.Entities;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface ISliderMainService
    {
        Task Delete(string id);
        Task<IEnumerable<SliderMain>> GetAll();
		Task<SliderMain> GetById(string id);
		Task Insert(SliderMain sliderMain);
        Task Update(SliderMain sliderMain);
    }
}
