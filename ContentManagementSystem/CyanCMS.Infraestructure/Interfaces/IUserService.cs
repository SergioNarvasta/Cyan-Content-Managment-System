using CMS.Dominio.Entidades;
using CyanCMS.Domain.Entities;

namespace CyanCMS.Infraestructure.Interfaces
{
	public interface IUserService
	{
		Task Delete(string id);
		Task<IEnumerable<User>> GetAll();
		Task<User> GetById(string id);
		Task Insert(User user);
		Task Update(User user);
	}
}
