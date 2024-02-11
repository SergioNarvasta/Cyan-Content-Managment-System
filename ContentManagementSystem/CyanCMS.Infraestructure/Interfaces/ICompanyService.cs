

using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;

namespace CyanCMS.Infraestructure.Interfaces
{
	public interface ICompanyService
	{
		Task<bool> Delete(string id);
		Task<IEnumerable<Company>> GetAll(CompanyParams @params);
		Task<Company> GetById(string company_Pk);
        int GetTotalCount();
        Task<CreateModel> Insert(Company model);
		Task<bool> Update(Company model);
	}
}
