using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Security;


namespace CyanCMS.Application.Services
{
    public class UserAppService : IUserAppService
    {
        public readonly IUserService _userService;
        public UserAppService(IUserService userService) {
            _userService = userService;
        }
        public async Task<bool> Delete(int id)
        {
            return await _userService.Delete(id);
        }

        public async Task<IEnumerable<User>> GetAll(UserParams @params)
        {
          return await _userService.GetAll(@params);
        }

        public Task<User> GetById(int id)
        {
            return _userService.GetById(id);
        }

        public async Task<bool> Insert(User model)
        {
            model.Token = Cryptography.EncryptValue(model.Token);
            model.AuditCreateDate = DateTime.Now;
            model.AuditCreateUser = "User";
            model.IsActive = true;
            model.IsDeleted = false;
            return await _userService.Insert(model);
        }

        public async Task<bool> Update(User model)
        {
            model.AuditUpdateDate = DateTime.Now;
            model.AuditUpdateUser = "User";
            return await _userService.Update(model);
        }
    }
}
