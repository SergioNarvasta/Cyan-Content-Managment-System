using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Dto;
using CyanCMS.Utils.Security;
using Microsoft.Extensions.Caching.Memory;

namespace CyanCMS.Application.Services
{
    public class SessionAppService : ISessionAppService
    {
        private readonly ISessionService _sessionService;
        private readonly IMemoryCache _memoryCache;
        private readonly TimeSpan TimeUserSession = TimeSpan.FromMinutes(240);
        public SessionAppService(ISessionService sessionService, IMemoryCache memoryCache)
        {
            _sessionService = sessionService;
            _memoryCache = memoryCache; 
        }

        public async Task<UserDto> GetSession(SessionDto request)
        {
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
            _memoryCache.Set(key, value, TimeUserSession);
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
