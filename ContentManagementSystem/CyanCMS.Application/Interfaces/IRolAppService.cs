using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CyanCMS.Application.Interfaces
{
    public interface IRolAppService
    {
        Task ConfigAddRolsInit(IServiceScope scope);
        Task<int> CountAsync();
        Task<bool> Insert(Rol rol);
        Task<bool> InsertMultipleRolInit();
    }
}
