using Microsoft.AspNetCore.Mvc;
using Site.Interfaces;
using Site.Models;

namespace HDProjectWeb.Models.Detalles
{
    [ViewComponent(Name = "SliderMain")]
    public class SliderMainViewComponent : ViewComponent
	{
        private readonly ISliderMainRepository _repository;
        public SliderMainViewComponent(ISliderMainRepository repository)
        {
            _repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _repository.Listado();
            return View(products);
        }
    }
}
