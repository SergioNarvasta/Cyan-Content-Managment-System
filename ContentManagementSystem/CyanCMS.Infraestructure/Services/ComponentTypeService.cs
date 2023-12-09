using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Data;
using CyanCMS.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CyanCMS.Infraestructure.Services
{
    public class ComponentTypeService : IComponentTypeService
    {
        private readonly AppDbContext _dbContext;
        public ComponentTypeService(AppDbContext dbContext) {  _dbContext = dbContext; }

        public async Task<bool> Insert(ComponentType model)
        {
            try
            {
                _dbContext.ComponentType.Add(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e) {
                Console.WriteLine(e);
                return false;
            }  
        }

        public async Task<int> GetCountData() {
            try
            {
                var list = await _dbContext
                    .ComponentType
                    .AsNoTracking()
                    .ToListAsync();
                return list.Count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }
}
