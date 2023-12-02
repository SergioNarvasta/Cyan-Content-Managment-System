
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
       
		public async Task Delete(string id)
        {
            var model = await _dbContext.Company
                 .Where(x => x.Company_Pk == id && x.Company_Estado == 0)
                 .AsNoTracking()
                 .FirstOrDefaultAsync();

            if(model!= null)
            {
                _dbContext.Company.Remove(model);
                await _dbContext.SaveChangesAsync();
            }  
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            var list = await _dbContext.Company.ToListAsync();
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

        public async Task Insert(Company company)
        {
            _dbContext.Company.Add(company);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Company model)
        {
            _dbContext.Company.Update(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}
