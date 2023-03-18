using CMS.Dominio.Entidades;
using CMS.Infraestructura.Data;
using CMS.Aplicacion.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CMS.Infraestructura.Repositorios
{
    public class UserCollection 
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private readonly IMongoCollection<User> collection;

        public UserCollection()
        {
            collection = _repository.db.GetCollection<User>("User");
        }
        public async Task DeleteUser(string id)
        {
            var filter = Builders<User>.Filter.Eq(s => s.User_Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await collection.FindAsync(new BsonDocument{ { "User_Estado", 1 } }
                ).Result.ToListAsync();
        }

        public async Task InsertUser(User user)
        {
            await collection.InsertOneAsync(user);
        }

        public async Task UpdateUser(User user)
        {
            var filter = Builders<User>
                .Filter
                .Eq(s => s.User_Id, user.User_Id);
            await collection.ReplaceOneAsync(filter, user);
        }

		public async Task<User> GetUserById(string id)
		{
			return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
				.Result.FirstAsync();
		}
	}
}
