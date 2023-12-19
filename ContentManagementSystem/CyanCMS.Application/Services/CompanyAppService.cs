using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;

namespace CyanCMS.Application.Services
{
    public class CompanyAppService : ICompanyAppService
    {
        public readonly ICompanyService _companyService;
        public CompanyAppService(ICompanyService companyService) {
           _companyService = companyService;
        }
        public async Task<bool> Delete(string id)
        {
            return await _companyService.Delete(id);
        }

        public async Task<IEnumerable<Company>> GetAll(CompanyParams @params)
        {
            return await _companyService.GetAll(@params);
        }

        public async Task<Company> GetById(string company_Pk)
        {
            return await _companyService.GetById(company_Pk);
        }

        public async Task<CreateModel> Insert(Company model)
        {
            model.AuditCreateDate = DateTime.Now;
            model.AuditCreateUser = "User";
            model.IsActive = true;
            model.IsDeleted = false;
            return await _companyService.Insert(model);
        }

        public async Task<bool> Update(Company model)
        {
            model.AuditUpdateDate = DateTime.Now;
            model.AuditUpdateUser = "User";
            return await _companyService.Update(model);
        }
    }
}
