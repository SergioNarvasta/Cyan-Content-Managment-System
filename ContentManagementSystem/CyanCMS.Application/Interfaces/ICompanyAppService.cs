using CyanCMS.Domain.Entities

namespace CyanCMS.Application.Interfaces
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
