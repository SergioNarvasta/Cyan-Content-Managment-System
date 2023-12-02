using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;


namespace CyanCMS.Application.Services
{
    public class UserAppService : IUserAppService
    {
        public readonly IUserService _userService;
        public UserAppService(IUserService userService) {
            _userService = userService;
        }
        public async Task Delete(string id)
        {
            await _userService.Delete(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
          return await _userService.GetAll();
        }

        public Task<User> GetById(string id)
        {
            return _userService.GetById(id);
        }

        public async Task Insert(User model)
        {
            await _userService.Insert(model);
        }

        public async Task Update(User model)
        {
            await _userService.Update(model);
        }
    }
}
