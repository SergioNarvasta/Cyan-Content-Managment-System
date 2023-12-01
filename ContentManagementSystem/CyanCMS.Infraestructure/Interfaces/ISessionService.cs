

using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;

namespace CMS.Aplicacion.Interfaces
{
	public interface ISessionService
	{
		Task<User> Session(SessionDto request);
	}
}
