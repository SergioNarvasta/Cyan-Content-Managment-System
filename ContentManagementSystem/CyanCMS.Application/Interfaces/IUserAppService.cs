using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Request;

namespace CyanCMS.Application.Interfaces
{
	public interface IUserAppService
	{
		Task<bool> Delete(int id);
		Task<IEnumerable<User>> GetAll(UserParams @params);
		Task<User> GetById(int id);
		Task<bool> Insert(User user);
		Task<bool> Update(User user);
	}
}
