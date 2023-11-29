using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using CMS.Infraestructura.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver.Core.Configuration;


namespace CMS.Infraestructura.Services
{
    public class UserService
    {
        public readonly AppDbContext _dbContext;
        private readonly string conn;
        public UserService(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("");
        }
        public async Task DeleteUser(string id)
        {
            using var connection = new SqlConnection(_dbContext.connectionString);
            await connection.QuerySingleAsync<int>(@"DELETE FROM User WHERE User_Pk = @id", new {id });
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
