using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Utils.Constants;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;
using Microsoft.Extensions.Caching.Memory;

namespace CyanCMS.Application.Services
{
    public class CompanyAppService(ICompanyService companyService,
        IMemoryCache memoryCache) : ICompanyAppService
    {
        public readonly ICompanyService _companyService = companyService;
        private readonly IMemoryCache _memoryCache = memoryCache;

        public async Task<bool> Delete(int id) => 
            await _companyService.Delete(id);
        

        public async Task<GenericDto<CompanyDto>> GetAll(CompanyParams @params) => 
            await _companyService.GetAll(@params);

        public async Task<List<CompanyDto>> GetByUserId(int userId) =>
           await _companyService.GetByUserId(userId);

        public async Task<CompanyDto> GetById(int id) =>
           await _companyService.GetById(id);

        public async Task<ResponseModel> Insert(Company model)
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

        public void SetCompaniesByUserSession_Cache(string key, List<CompanyDto> companies)
        {
            _memoryCache.Set(key, companies, TimeSession.UserSession);
        }

        public List<CompanyDto> GetCompaniesByUserSession_Cache(string key)
        {
            var companies = _memoryCache.Get<List<CompanyDto>>(key);
            var companyDtos = new List<CompanyDto>();
            return companies ?? companyDtos;
        }
    }
}
