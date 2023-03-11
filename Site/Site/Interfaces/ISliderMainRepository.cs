

using Site.Models;

namespace Site.Interfaces
{
    public interface ISliderMainRepository
    {
        Task<IEnumerable<SliderMain>> Listado();
    }
}
