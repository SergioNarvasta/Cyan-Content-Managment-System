using Microsoft.AspNetCore.Mvc;
using Site.Interfaces;
using Site.Models;
using Site.Repositorios;

namespace HDProjectWeb.Models.Detalles
{
    [ViewComponent(Name = "SiteMenuOptions")]
    public class SiteMenuOptionsViewComponent : ViewComponent
	{
        private readonly ISiteMenuOptionsRepository _repository;
        public SiteMenuOptionsViewComponent(ISiteMenuOptionsRepository repository)
        {
            _repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {  
            var products = await _repository.ListaMenuOpciones();
            return View(products);
        }
    }
}
