
using CyanCMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using CyanCMS.Utils.Response;

namespace CyanCMS.Infraestructure.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly AppDbContext _dbContext;
        public ConfigurationService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Configuration>> GetByCompanyId(int companyId)
        {
            return await _dbContext
                 .Configuration
                 .Where(s => s.CompanyId== companyId)
                 .AsNoTracking()
                 .ToListAsync();               
        }
        public async Task<Configuration> GetById(string id)
        {
            var configurationEmpty = new Configuration();
            return await _dbContext
                .Configuration
                .FindAsync(id) ?? configurationEmpty;             
        }
        public async Task<int> GetCountByCompany(int companyId)
        {
            var list = await _dbContext
                 .Configuration
                 .Where(s => s.CompanyId == companyId)
                 .AsNoTracking()
                 .ToListAsync();

            return list.Count;
        }
        public async Task<CreateModel> Insert(Configuration model)
        {
            var createModel = new CreateModel();
            try
            {
                _dbContext.Configuration.Add(model);
                await _dbContext.SaveChangesAsync();

                createModel.WasCreated = true;
                createModel.Message = "La operación de inserción fue exitosa";
                createModel.Id = model.Id; 

                return createModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                createModel.WasCreated = false;
                createModel.Message = "Error durante la operación de inserción";
                createModel.Id = 0; 
                return createModel;
            }
        }

        public async Task<bool> Update(Configuration model)
        {
            try
            {
                _dbContext.Configuration.Update(model);
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
