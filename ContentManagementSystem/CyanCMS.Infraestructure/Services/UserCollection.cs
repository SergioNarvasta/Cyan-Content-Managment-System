
using CMS.Infraestructura.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Domain.Entities;

namespace SmartCMS.Infraestructure.Services
{
    public class UserCollection : IUserService
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private readonly IMongoCollection<User> collection;

        public UserCollection()
        {
            collection = _repository.db.GetCollection<User>("User");
        }
        public async Task Delete(string id)
        {
            var filter = Builders<User>.Filter.Eq(s => s.User_Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await collection.FindAsync(new BsonDocument { { "User_Estado", 1 } }
                ).Result.ToListAsync();
        }

        public async Task Insert(User model)
        {
            await collection.InsertOneAsync(model);
        }

        public async Task Update(User model)
        {
            var filter = Builders<User>
                .Filter
                .Eq(s => s.User_Id, model.User_Id);
            await collection.ReplaceOneAsync(filter, model);
        }

        public async Task<User> GetById(string id)
        {
            return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
                .Result.FirstAsync();
        }
    }
}
