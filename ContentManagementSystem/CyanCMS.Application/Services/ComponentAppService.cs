using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;

namespace CyanCMS.Application.Services
{
    public class ComponentAppService : IComponentAppService
    {
        public readonly IComponentService _componentService;
        public ComponentAppService(IComponentService componentService) {
           _componentService = componentService;
        }
        public async Task<bool> Delete(string id)
        {
            return await _componentService.Delete(id);
        }

        public async Task<IEnumerable<Component>> GetAll(ComponentParams @params)
        {
            return await _componentService.GetAll(@params);
        }

        public async Task<Component> GetById(string ComponentId)
        {
            return await _componentService.GetById(ComponentId);
        }

        public async Task<CreateModel> Insert(Component model)
        {
            model.AuditCreateDate = DateTime.Now;
            model.AuditCreateUser = "User";
            model.IsActive = true;
            model.IsDeleted = false;
            return await _componentService.Insert(model);
        }

        public async Task<bool> Update(Component model)
        {
            model.AuditUpdateDate = DateTime.Now;
            model.AuditUpdateUser = "User";
            return await _componentService.Update(model);
        }
    }
}
