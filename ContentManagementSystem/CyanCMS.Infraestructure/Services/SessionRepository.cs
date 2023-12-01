using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using CMS.Infraestructura.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using CyanCMS.Domain.Entities;
using CyanCMS.Domain.Dto;

namespace SmartCMS.Infraestructure.Services
{
    public class SessionRepository : ISessionService
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private readonly IMongoCollection<User> collection;

        public SessionRepository()
        {
            collection = _repository.db.GetCollection<User>("User");
        }
        public async Task<User> Session(SessionDto request)
        {
            User user = await collection.FindAsync(new BsonDocument
               { { "User_Email", request.correo },{ "User_Token",request.clave } })
               .Result.FirstAsync();
            user.User_Token = user.User_Pk;
            user.User_Telefono = 999999999;
            return user;
        }
    }
}
