using CMS.Dominio.Entidades;
using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Request;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IConfigurationService
    {
        Task<List<Configuration>> GetByCompanyId(int companyId);
        Task<Configuration> GetById(string id);
        Task<int> GetCountByCompany(int companyId);
        Task<bool> Insert(Configuration model);
        Task<bool> Update(Configuration model);
    }
}
