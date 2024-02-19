using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;

namespace CyanCMS.Application.Interfaces
{
	public interface ICompanyAppService
	{
		Task<bool> Delete(int id);
		Task<GenericDto<CompanyDto>> GetAll(CompanyParams @params);
		Task<CompanyDto> GetById(int id);
        Task<ResponseModel> Insert(Company model);
		Task<bool> Update(Company model);
	}
}
