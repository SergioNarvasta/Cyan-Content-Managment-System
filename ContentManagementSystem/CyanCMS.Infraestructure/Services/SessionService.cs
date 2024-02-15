
using CyanCMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CMS.Infraestructure.Interfaces;
using CyanCMS.Domain.Dto;
using Microsoft.EntityFrameworkCore;

namespace CyanCMS.Infraestructure.Services
{
    public class SessionService : ISessionService
    {
        private readonly AppDbContext _dbContext;
        public SessionService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        public async Task<UserDto> GetSession(SessionDto request)
        {
            return await _dbContext
                    .User
                    .Where(s => !s.IsDeleted && s.IsActive 
                              && s.UserEmail == request.UserName 
                              && s.UserToken == request.Token)
                    .Select(s => new UserDto
                    {
                        UserName = s.UserName,
                        UserId = s.UserId,
                        UserEmail = s.UserEmail,
                        UserLastName = s.UserLastName,
                        IsActive = s.IsActive,
                        IsDeleted = s.IsDeleted            
                    })
                    .FirstOrDefaultAsync() ?? new UserDto();                  
        }

        public async Task<bool> UserNameExists(string username)
        {
            try
            {
                var validUserName = await _dbContext
                    .User
                    .Where(s => !s.IsDeleted && s.IsActive && s.UserEmail == username)
                    .CountAsync();
                return validUserName > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            } 
        }

        
    }
}
