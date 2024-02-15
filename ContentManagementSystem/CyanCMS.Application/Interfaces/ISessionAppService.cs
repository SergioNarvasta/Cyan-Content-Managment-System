using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;

namespace CyanCMS.Application.Interfaces
{
	public interface ISessionAppService
	{
		Task<UserDto> GetSession(SessionDto request);
	}
}
