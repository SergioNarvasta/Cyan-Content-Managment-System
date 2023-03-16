using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using CMS.Infraestructura.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Configuration;


namespace CMS.Infraestructura.Servicios
{
    public class UserService : IUserAppService
    {
        public readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task DeleteUser(string id)
        {
            using var connection = new SqlConnection(_dbContext.connectionString);
            await connection.QuerySingleAsync<int>(@" ", new { });
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            var list = await _dbContext.User.ToListAsync();
            return list;
        }

        public async Task<User> GetUserById(string id)
        {
            User? user = new User();
            user = await _dbContext.User.FindAsync(id);
            return user;
        }

        public async Task InsertUser(User user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            using var connection = new SqlConnection(_dbContext.connectionString);
            await connection.QuerySingleAsync<int>(@" ", new { });
        }
    }
}
