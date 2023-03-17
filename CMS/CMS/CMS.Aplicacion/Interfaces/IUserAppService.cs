using CMS.Dominio.Entidades;

namespace CMS.Aplicacion.Interfaces
{
	public interface IUserAppService
	{
		Task DeleteUser(string id);
		Task<IEnumerable<User>> GetAllUser();
		Task<User> GetUserById(string id);
		Task InsertUser(User user);
		Task UpdateUser(User user);
	}
}
