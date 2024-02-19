using CyanCMS.Domain.Dto;

namespace CyanCMS.Infraestructure.Interfaces
{
	public interface ISessionService
	{
		Task<UserDto> GetSession(SessionDto request);
        Task<bool> UserNameExists(string username);
    }
}
