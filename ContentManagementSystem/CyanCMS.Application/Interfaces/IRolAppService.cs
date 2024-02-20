using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;

namespace CyanCMS.Application.Interfaces
{
    public interface IRolAppService
    {
        Task<bool> Insert(Rol rol);
    }
}
