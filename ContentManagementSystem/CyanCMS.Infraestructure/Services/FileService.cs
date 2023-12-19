
using CyanCMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using CyanCMS.Utils.Request;

namespace CyanCMS.Infraestructure.Services
{
    public class FileService : IUserService
    {
        private readonly AppDbContext _dbContext;
        public FileService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Delete(string id)
        {
            try
            {
                var model = await _dbContext.File.FindAsync(id);
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

        public async Task<List<File>> GetByCompany(int companyId)
        {
            var query = _dbContext.File
                .AsQueryable();

            var list = await query
                 .Where(s => !s.IsDeleted && s.CompanyId == companyId)
                 .AsNoTracking()
                 .ToListAsync();

            return list
               
        }

        public async Task<User> GetById(string id)
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
    }
}
