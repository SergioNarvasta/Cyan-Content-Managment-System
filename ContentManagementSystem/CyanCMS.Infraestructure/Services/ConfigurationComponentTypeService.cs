using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Data;
using CyanCMS.Infraestructure.Interfaces;

namespace CyanCMS.Infraestructure.Services
{
    public class ConfigurationComponentTypeService : IConfigurationComponentTypeService
    {
        private readonly AppDbContext _dbContext;
        public ConfigurationComponentTypeService(AppDbContext dbContext) {  _dbContext = dbContext; }

        public async Task<bool> Insert(ConfigurationComponentType model)
        {
            try
            {
                _dbContext.ConfigurationComponentType.Add(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e) {
                Console.WriteLine(e);
                return false;
            }  
        }
 
    }
}
