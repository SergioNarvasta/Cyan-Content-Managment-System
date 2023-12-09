

using CyanCMS.Domain.Entities;

namespace CyanCMS.Infraestructure.Interfaces
{
	public interface ICompanyService
	{
		Task<bool> Delete(string id);
		Task<IEnumerable<Company>> GetAll();
		Task<Company> GetById(string company_Pk);
		Task<bool> Insert(Company model);
		Task<bool> Update(Company model);
	}
}
