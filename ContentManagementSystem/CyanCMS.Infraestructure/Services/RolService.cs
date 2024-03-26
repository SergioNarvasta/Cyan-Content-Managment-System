using CyanCMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CyanCMS.Infraestructure.Services
{
    public class RolService : IRolService
    {
        private readonly AppDbContext _dbContext;
        public RolService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountAsync()
        {
            try
            {
                return await
                _dbContext.Rol.CountAsync();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
        public async Task<bool> Insert(Rol rol)
        {
            try
            {
                _dbContext.Rol.Add(rol);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            } 
        }

        public async Task<Rol> FindByName(string name)
        {
            try
            {
                return await
                _dbContext.Rol
                .Where(s=>s.Name == name)
                .FirstAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}
