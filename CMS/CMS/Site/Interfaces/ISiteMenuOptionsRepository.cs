using Site.Models;

namespace Site.Interfaces
{
	public interface ISiteMenuOptionsRepository
	{
		Task<IEnumerable<SiteMenuOptions>> ListaMenuOpciones();
	}
}
