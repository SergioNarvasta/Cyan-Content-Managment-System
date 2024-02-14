using Microsoft.EntityFrameworkCore;
using CyanCMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;

namespace CyanCMS.Infraestructure.Services
{
    public class CompanyService : ICompanyService
    {
        public readonly AppDbContext _dbContext;
        public CompanyService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var model = await _dbContext
                    .Company
                    .FindAsync(id);

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

        public async Task<IEnumerable<Company>> GetAll(CompanyParams @params)
        {
            var query = _dbContext.Company
                .AsQueryable();

            if (!string.IsNullOrEmpty(@params.CompanyName))
            {
                query = query.Where(s =>
                   s.CompanyName.Contains(@params.CompanyName)
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

            var list = await query
                 .Where(s => !s.IsDeleted)
                 .AsNoTracking()
                 .ToListAsync();

            return list
                .Skip(@params.PageNumber)
                .Take(@params.PageSize)
                .ToList();
        }

        public int GetTotalCount()
        {
            return _dbContext.Company
                 .Where(s => !s.IsDeleted)
                 .AsNoTracking()
                 .ToListAsync()
                 .Result
                 .Count;
        }

        public async Task<Company> GetById(string id)
        {
            Company companyEmpty = new Company();
            return await _dbContext
                .Company
                .FindAsync(id) ?? companyEmpty;
        }

        public async Task<CreateModel> Insert(Company model)
        {
            var createModel = new CreateModel();
            try
            {
                _dbContext.Company.Add(model);
                int insert = await _dbContext.SaveChangesAsync();
                createModel.WasCreated = true;
                createModel.Message = "Se registro con exito";
                createModel.Id = model.CompanyId; 
                
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

        public async Task<bool> Update(Company model)
        {
            try
            {
                _dbContext.Company.Update(model);
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
