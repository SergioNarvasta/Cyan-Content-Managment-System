using CyanCMS.Domain.Entities;

namespace CyanCMS.Application.Interfaces
{
    public interface IFileAppService
    {
        Task<bool> Delete(int id);
        Task<FileUnit> GetByCompany(int companyId);
        Task<List<FileUnit>> GetByComponent(int componentId);
        Task<bool> Insert(FileUnit model);
        Task<bool> Update(FileUnit model);
    }
}
