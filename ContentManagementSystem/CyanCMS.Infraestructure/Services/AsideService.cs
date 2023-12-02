
using CMS.Infraestructura.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;

namespace SmartCMS.Infraestructure.Services
{
    public class AsideService : IAsideService
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private readonly IMongoCollection<Aside> collection;

        public AsideService()
        {
            collection = _repository.db.GetCollection<Aside>("Aside");
        }
        public async Task Delete(string id)
        {
            var filter = Builders<Aside>.Filter.Eq(s => s.Aside_Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Aside>> GetAll()
        {
            //Filtrar campo estado
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task Insert(Aside model)
        {
            await collection.InsertOneAsync(model);
        }

        public async Task Update(Aside model)
        {
            var filter = Builders<Aside>
                .Filter
                .Eq(s => s.Aside_Id, model.Aside_Id);
            await collection.ReplaceOneAsync(filter, model);
        }

        public async Task<Aside> GetById(string id)
        {
            return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
                .Result.FirstAsync();
        }
    }
}
