
using CyanCMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
                var model = await _dbContext.Company
                 .Where(x => x.CompanyId.ToString() == id
                             && x.IsActive
                             && !x.IsDeleted)
                 .AsNoTracking()
                 .FirstOrDefaultAsync();

                if (model != null)
                {
                    _dbContext.Company.Remove(model);
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

        public async Task<IEnumerable<Company>> GetAll()
        {
            var list = await _dbContext
                .Company
                .AsNoTracking()
                .ToListAsync();
            return list;
        }

        public async Task<Company> GetById(string id)
        {
            Company companyEmpty = new Company();
            var company = await _dbContext.Company.FindAsync(id);
            if (company == null)
                return companyEmpty;
            return company;
        }

        public async Task<bool> Insert(Company company)
        {
            try
            {
                _dbContext.Company.Add(company);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
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
