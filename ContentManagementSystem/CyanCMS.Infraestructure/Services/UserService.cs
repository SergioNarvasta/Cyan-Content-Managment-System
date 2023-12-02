
using CyanCMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CyanCMS.Infraestructure.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly string connection;
        public UserService(IConfiguration configuration, AppDbContext dbContext)
        {
            connection = configuration.GetConnectionString("AzureSQLDatabaseConnection");
            _dbContext = dbContext;
        }
        public async Task Delete(string id)
        {
            using var cn = new SqlConnection(connection);
            await cn.QuerySingleAsync<int>(@"DELETE FROM User WHERE User_Pk = @id", new {id });
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var list = await _dbContext.User.ToListAsync();
            return list;
        }

        public async Task<User> GetById(string id)
        {
            User? user = new User();
            user = await _dbContext.User.FindAsync(id);
            return user;
        }

        public async Task Insert(User user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _dbContext.User.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
