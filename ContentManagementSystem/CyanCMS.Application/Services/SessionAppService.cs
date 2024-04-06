using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Dto;
using CyanCMS.Utils.Security;
using Microsoft.Extensions.Caching.Memory;
using CyanCMS.Utils.Constants;

namespace CyanCMS.Application.Services
{
    public class SessionAppService(ISessionService sessionService,
        IMemoryCache memoryCache) : ISessionAppService
    {
        private readonly ISessionService _sessionService = sessionService;
        private readonly IMemoryCache _memoryCache = memoryCache;

        public async Task<UserDto> GetSession(SessionDto request)
        {

            // Add IMemoryCache UserName List & Update 
            var userNameExists = await _sessionService.UserNameExists(request.UserName);
         
            // Encrypt to compare Token Encripted in Db
            request.Token = Cryptography.EncryptValue(request.Token);
            if (userNameExists)
            {
                var session = await _sessionService.GetSession(request);
                return session ?? new UserDto();
            }
            return new UserDto();
        }

        public void SetUserSession(string key, string value)
        {
            _memoryCache.Set(key, value, TimeSession.UserSession);
        }

        public string GetUserSession(string key)
        {
            return _memoryCache.Get<string>(key) ?? string.Empty;
        }

        public void RemoveUserSession(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
