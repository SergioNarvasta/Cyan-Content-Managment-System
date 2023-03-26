using CMS.Dominio.Entidades;

namespace CMS.Aplicacion.Interfaces
{
	public interface IUserAppService
	{
		Task Delete(string id);
		Task<IEnumerable<User>> GetAll();
		Task<User> GetById(string id);
		Task Insert(User user);
		Task Update(User user);
	}
}
