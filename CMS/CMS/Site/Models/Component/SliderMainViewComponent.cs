using Microsoft.AspNetCore.Mvc;
using Site.Interfaces;
using Site.Models;

namespace HDProjectWeb.Models.Detalles
{
    [ViewComponent(Name = "SliderMain")]
    public class SliderMainViewComponent : ViewComponent
	{
        private readonly ISliderMainRepository _repository;
        private readonly IConfiguration _configuration;
        public SliderMainViewComponent(ISliderMainRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration; 
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var company_Pk = _configuration["Company_Pk"];
            var list = await _repository.GetByCompanyPk(company_Pk);
            return View(list);
        }
    }
}
