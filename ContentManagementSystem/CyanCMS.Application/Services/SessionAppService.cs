using CMS.Infraestructure.Interfaces;
using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;

namespace CyanCMS.Application.Services
{
    public class SessionAppService : ISessionAppService
    {
        private readonly ISessionService _sessionService;
        public SessionAppService(ISessionService sessionService) {
            _sessionService = sessionService;
        }

        public async Task<UserDto> GetSession(SessionDto request)
        {
            var userNameExists = await _sessionService.UserNameExists(request.UserName);
            if (userNameExists)
            {
                var session = await _sessionService.GetSession(request);
                return session ?? new UserDto();
            }
             return new UserDto();
        }
    }
}
