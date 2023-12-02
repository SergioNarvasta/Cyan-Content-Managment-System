
using Dapper;
using Microsoft.Data.SqlClient;
using CyanCMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CyanCMS.Domain.Dto;
using Microsoft.EntityFrameworkCore;


namespace CyanCMS.Infraestructure.Services
{
    public class SessionService 
    {
        public readonly AppDbContext _dbContext;
        public SessionService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<User> Session(SessionDto request)
        {
            string User_Email = request.correo;
            string User_Token = request.clave;

            return await _dbContext.User
                .Where(s => string.Equals(s.User_Email, User_Email) && string.Equals(s.User_Token, User_Token))
                .FirstAsync();
           

        }
    }
}
