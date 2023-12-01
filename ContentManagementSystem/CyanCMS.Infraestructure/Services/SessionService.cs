
using Dapper;
using Microsoft.Data.SqlClient;
using CMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;


namespace CMS.Infraestructura.Services
{
    public class SessionService 
    {
        public readonly AppDbContext _dbContext;
        public SessionService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<User> Session(Dtosesion request)
        {
            string User_Email = request.correo;
            string User_Token = request.clave;
            using var connection = new SqlConnection(_dbContext.connectionString);
            return await connection.QueryFirstOrDefaultAsync<User>(@"SELECT * FROM User 
                            WHERE User_Email= @User_Email AND User_Token = @User_Token ", 
                            new { User_Email, User_Token });

        }
    }
}
