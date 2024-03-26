using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Common;
using Microsoft.Extensions.DependencyInjection;

namespace CyanCMS.Application.Services
{
    public class RolAppService : IRolAppService
    {
        private readonly IRolService _rolService;
        private readonly IUserAppService _userAppService;

        public RolAppService(IRolService rolService, IUserAppService userAppService)
        {
            _rolService = rolService;
            _userAppService = userAppService;
           
        }
        public async Task<bool> Insert(Rol model)
        {
            model.AuditCreateDate = DateTime.Now;
            model.AuditCreateUser = "User";
            model.IsActive = true;
            model.IsDeleted = false;
            return await _rolService.Insert(model);
        }
        public async Task<Rol> FindByName(string name)
        {
            return await _rolService.FindByName(name);
        }
        public async Task<int> CountAsync()
        {
            return await _rolService.CountAsync();
        }

        public async Task<bool> InsertMultipleRolInit()
        {
            bool response=false;
            var rolList = Enums.GetRolsFromEnum();
            foreach (var rol in rolList)
            {
                response = await this.Insert(rol);
            }
            return response;
        }

        public async Task ConfigAddRolsInit(IServiceScope scope)
        {
            var count = await this.CountAsync();
            string adminRolStr = "Admin";
            if (count == 0)
            {
                await this.InsertMultipleRolInit();
                var adminRol = await this.FindByName(adminRolStr);

                User user = new()
                {
                    Name = "Admin",
                    Email = "admin@innovait.pe",
                    Token = "cyancms",
                    RolId = adminRol?.Id ?? 1,
                };
                await _userAppService.Insert(user);
            }       
        }
    }
}
