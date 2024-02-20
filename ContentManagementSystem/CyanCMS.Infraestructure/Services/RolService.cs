using CyanCMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;

namespace CyanCMS.Infraestructure.Services
{
    public class RolService : IRolService
    {
        private readonly AppDbContext _dbContext;
        public RolService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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

    }
}
