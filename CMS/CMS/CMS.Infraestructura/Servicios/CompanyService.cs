using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using CMS.Infraestructura.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infraestructura.Servicios
{
    public class CompanyService : ICompanyAppService
	{
        public readonly AppDbContext _dbContext;
        public CompanyService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
		public async Task DeleteCompany(string id)
        {
            using var connection = new SqlConnection(_dbContext.connectionString);
            await connection.QuerySingleAsync<int>(@" ", new { });
        }

        public async Task<IEnumerable<Company>> GetAllCompany()
        {
            var list = await _dbContext.Company.ToListAsync();
            return list;
        }

        public async Task<Company> GetCompanyById(string id)
        {
			Company? company = new Company();
			company = await _dbContext.Company.FindAsync(id);
            return company;
        }

        public async Task InsertCompany(Company company)
        {
            _dbContext.Company.Add(company);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCompany(Company company)
        {
            using var connection = new SqlConnection(_dbContext.connectionString);
            await connection.QuerySingleAsync<int>(@" ", new { });
        }
    }
}
