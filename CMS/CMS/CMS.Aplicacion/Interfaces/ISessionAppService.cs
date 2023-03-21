using CMS.Dominio.Entidades;
using CMS.Dominio.Dto;

namespace CMS.Aplicacion.Interfaces
{
	public interface ISessionAppService
	{
		Task<User> Session(Dtosesion request);
	}
}
