

using Site.Models;

namespace Site.Interfaces
{
    public interface ISliderMainRepository
    {
        Task<IEnumerable<SliderMain>> GetByCompanyPk(string company_Pk);
        Task<IEnumerable<SliderMain>> Listado();
    }
}
