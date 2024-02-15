

using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;

namespace CMS.Infraestructure.Interfaces
{
	public interface ISessionService
	{
		Task<UserDto> GetSession(SessionDto request);
        Task<bool> UserNameExists(string username);
    }
}
