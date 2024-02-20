using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;


namespace CyanCMS.Application.Services
{
    public class RolAppService : IRolAppService
    {
        private readonly IRolService _rolService;
        
        public RolAppService(IRolService rolService)
        {
            _rolService = rolService;
           
        }
        public async Task<bool> Insert(Rol rol)
        {
            return await _rolService.Insert(rol);
        }

    }
}
