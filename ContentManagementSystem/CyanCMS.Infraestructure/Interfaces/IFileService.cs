

using CyanCMS.Domain.Entities;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IFileService
    {
        Task<bool> Delete(int id);
        Task<FileUnit> GetByCompany(int companyId);
        Task<List<FileUnit>> GetByComponent(int componentId);
        Task<bool> Insert(FileUnit file);
        Task<bool> Update(FileUnit file);
    }
}
