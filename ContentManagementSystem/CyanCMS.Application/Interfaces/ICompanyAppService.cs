using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Request;

namespace CyanCMS.Application.Interfaces
{
	public interface ICompanyAppService
	{
		Task<bool> Delete(string id);
		Task<IEnumerable<Company>> GetAll(CompanyParams @params);
		Task<Company> GetById(string company_Pk);
		Task<bool> Insert(Company model);
		Task<bool> Update(Company model);
	}
}
