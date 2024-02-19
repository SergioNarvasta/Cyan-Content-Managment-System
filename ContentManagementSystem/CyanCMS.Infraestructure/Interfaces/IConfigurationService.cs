using CMS.Dominio.Entidades;
using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IConfigurationService
    {
        Task<List<Configuration>> GetByCompanyId(int companyId);
        Task<Configuration> GetById(int id);
        Task<int> GetCountByCompany(int companyId);
        Task<CreateModel> Insert(Configuration model);
        Task<bool> Update(Configuration model);
    }
}
