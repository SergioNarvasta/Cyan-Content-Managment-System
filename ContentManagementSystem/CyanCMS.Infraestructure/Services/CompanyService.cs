
using CMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infraestructura.Services
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
            //using var connection = new SqlConnection(_dbContext.connectionString);
            //await connection.QuerySingleAsync<int>(@" ", new { });
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

        public async Task Update(Company company)
        {
            //using var connection = new SqlConnection(_dbContext.connectionString);
            //await connection.QuerySingleAsync<int>(@" ", new { });
        }
    }
}
