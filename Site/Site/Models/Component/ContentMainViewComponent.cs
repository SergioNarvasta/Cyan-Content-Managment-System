using Microsoft.AspNetCore.Mvc;
using Site.Interfaces;
using Site.Models;

namespace HDProjectWeb.Models.Detalles
{
    [ViewComponent(Name = "ContentMain")]
    public class ContentMainViewComponent : ViewComponent
	{
        private readonly IContentMainRepository _repository;
        public ContentMainViewComponent(IContentMainRepository repository)
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
