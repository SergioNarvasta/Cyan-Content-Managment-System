using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;


namespace CyanCMS.Application.Services
{
    public class UserAppService : IUserAppService
    {
        public readonly IUserAppService _userAppService;
        public UserAppService(IUserAppService userAppService) {
            _userAppService = userAppService;
        }
        public async Task Delete(string id)
        {
            await _userAppService.Delete(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
          return await _userAppService.GetAll();
        }

        public Task<User> GetById(string id)
        {
            return _userAppService.GetById(id);
        }

        public async Task Insert(User model)
        {
            await _userAppService.Insert(model);
        }

        public async Task Update(User model)
        {
            await _userAppService.Update(model);
        }
    }
}
