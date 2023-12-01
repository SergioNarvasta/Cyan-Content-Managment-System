
using CMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CMS.Infraestructura.Services
{
    public class UserService
    {
        public readonly AppDbContext _dbContext;
        private readonly string connection;
        public UserService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("AzureSQLDatabaseConnection");
        }
        public async Task DeleteUser(string id)
        {
            using var cn = new SqlConnection(connection);
            await cn.QuerySingleAsync<int>(@"DELETE FROM User WHERE User_Pk = @id", new {id });
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
            using var cn = new SqlConnection(connection);
            await cn.QuerySingleAsync<int>(@" ", new { });
        }
    }
}
