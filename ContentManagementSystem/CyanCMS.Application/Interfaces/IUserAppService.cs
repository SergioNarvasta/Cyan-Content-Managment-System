using CyanCMS.Domain.Entities;

namespace CyanCMS.Application.Interfaces
{
	public interface IUserAppService
	{
		Task<bool> Delete(string id);
		Task<IEnumerable<User>> GetAll();
		Task<User> GetById(string id);
		Task<bool> Insert(User user);
		Task<bool> Update(User user);
	}
}
