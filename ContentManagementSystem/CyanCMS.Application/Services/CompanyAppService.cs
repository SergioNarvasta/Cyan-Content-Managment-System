using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;

namespace CyanCMS.Application.Services
{
    public class CompanyAppService : ICompanyAppService
    {
        public readonly ICompanyService _companyService;
        public CompanyAppService(ICompanyService companyService) {
           _companyService = companyService;
        }
        public async Task Delete(string id)
        {
            await _companyService.Delete(id);
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _companyService.GetAll();
        }

        public async Task<Company> GetById(string company_Pk)
        {
            return await _companyService.GetById(company_Pk);
        }

        public async Task Insert(Company model)
        {
            await _companyService.Insert(model);
        }

        public async Task Update(Company model)
        {
            await _companyService.Update(model);
        }
    }
}
