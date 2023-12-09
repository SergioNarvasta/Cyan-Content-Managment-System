
using CyanCMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CyanCMS.Infraestructure.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Delete(string id)
        {
            try
            {
                var model = await _dbContext.User.FindAsync(id);
                if (model != null)
                {
                    _dbContext.Remove(model);
                    await _dbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            } 
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var list = await _dbContext
                .User
                .AsNoTracking()
                .ToListAsync();
            return list;
        }

        public async Task<User> GetById(string id)
        {
            return await _dbContext.User.FindAsync(id);  
        }

        public async Task<bool> Insert(User user)
        {
            try
            {
                _dbContext.User.Add(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            } 
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                _dbContext.User.Update(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }  
        }
    }
}
