using CyanCMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using CyanCMS.Utils.Request;

namespace CyanCMS.Infraestructure.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var model = await _dbContext.User.FindAsync(id);
                if (model != null)
                {
                    model.IsDeleted = true;
                    await this.Update(model);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            } 
        }

        public async Task<IEnumerable<User>> GetAll(UserParams @params)
        {
            var query = _dbContext.User
                .AsQueryable();

            if (!string.IsNullOrEmpty(@params.UserName))
            {
                query = query.Where(s =>
                   s.Name.Contains(@params.UserName)
                );
            }

            bool isActive;
            if (bool.TryParse(@params.IsActiveStr, out isActive) &&
                !string.IsNullOrEmpty(@params.IsActiveStr))
            {
                query = query
                    .Where(s => s.IsActive == isActive
                );
            }

            if (!string.IsNullOrEmpty(@params.RolId))
            {
                query = query.Where(s =>
                   s.RolId == int.Parse(@params.RolId)  
                );
            }

            if (!string.IsNullOrEmpty(@params.PlanId))
            {
                query = query.Where(s =>
                   s.PlanId == int.Parse(@params.PlanId)
                );
            }

            var list = await query
                 .Where(s => !s.IsDeleted)
                 .AsNoTracking()
                 .ToListAsync();

            return list
                .Skip(@params.PageNumber)
                .Take(@params.PageSize);
        }

        public async Task<User> GetById(int id)
        {
            var userEmpty = new User();
            return await _dbContext
                .User
                .FindAsync(id) ?? userEmpty;             
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
