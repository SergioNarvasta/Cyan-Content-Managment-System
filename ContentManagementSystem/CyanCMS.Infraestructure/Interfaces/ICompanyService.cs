
using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;

namespace CyanCMS.Infraestructure.Interfaces
{
	public interface ICompanyService
	{
		Task<bool> Delete(string id);
		Task<GenericDto<CompanyDto>> GetAll(CompanyParams @params);
		Task<CompanyDto> GetById(int Id);
        Task<ResponseModel> Insert(Company model);
		Task<bool> Update(Company model);
	}
}
