using CMS.Dominio.Entidades;

namespace CMS.Dominio.Interfaces.Repositorios
{
    public interface ISliderMainRepository
    {
        Task DeleteSliderMain(string id);
        Task<IEnumerable<SliderMain>> GetAllSliderMain();
        Task InsertSliderMain(SliderMain contentmain);
        Task UpdateSliderMain(SliderMain contentmain);
    }
}
