
using CyanCMS.Infraestructure.Data;
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
                              && s.Email == request.UserName 
                              && s.Token == request.Token)
                    .Select(s => new UserDto
                    {
                        Name = s.Name,
                        Id = s.Id,
                        Email = s.Email,
                        LastName = s.LastName,
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
                    .Where(s => !s.IsDeleted && s.IsActive && s.Email == username)
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
