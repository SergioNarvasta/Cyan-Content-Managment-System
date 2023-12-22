using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;

namespace CyanCMS.Application.Services
{
    public class FileAppService : IFileAppService
    {
        public readonly IFileService _fileService;
        public FileAppService(IFileService fileService) {
           _fileService = fileService;
        }
        public async Task<bool> Delete(int id)
        {
            return await _fileService.Delete(id);
        }

        public async Task<FileUnit> GetByCompany(int companyId)
        {
            return await _fileService.GetByCompany(companyId);
        }

        public async Task<List<FileUnit>> GetByComponent(int componentId)
        {
            return await _fileService.GetByComponent(componentId);
        }

        public async Task<bool> Insert(FileUnit model)
        {
            model.AuditCreateDate = DateTime.Now;
            model.AuditCreateUser = "User";
            model.IsActive = true;
            model.IsDeleted = false;
            return await _fileService.Insert(model);
        }

        public async Task<bool> Update(FileUnit model)
        {
            model.AuditUpdateDate = DateTime.Now;
            model.AuditUpdateUser = "User";
            return await _fileService.Update(model);
        }
    }
}
