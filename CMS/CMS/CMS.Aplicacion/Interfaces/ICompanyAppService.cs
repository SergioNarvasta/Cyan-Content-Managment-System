using CMS.Dominio.Entidades;

namespace CMS.Aplicacion.Interfaces
{
	public interface ICompanyAppService
	{
		Task Delete(string id);
		Task<IEnumerable<Company>> GetAll();
		Task<Company> GetById(string company_Pk);
		Task Insert(Company model);
		Task Update(Company model);
	}
}
