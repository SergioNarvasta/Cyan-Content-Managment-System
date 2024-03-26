using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CyanCMS.Application.Interfaces
{
    public interface IRolAppService
    {
        Task ConfigUserRolsInit();
        Task<int> CountAsync();
        Task<bool> Insert(Rol rol);
        Task<bool> InsertMultipleRolInit();
    }
}
