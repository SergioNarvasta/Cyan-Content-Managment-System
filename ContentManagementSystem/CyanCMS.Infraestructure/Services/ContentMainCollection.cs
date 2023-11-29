using CMS.Dominio.Entidades;
using CMS.Infraestructura.Data;
using CMS.Aplicacion.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartCMS.Infraestructure.Services
{
    public class ContentMainCollection : IContentMainAppService
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private readonly IMongoCollection<ContentMain> collection;

        public ContentMainCollection()
        {
            collection = _repository.db.GetCollection<ContentMain>("ContentMain");
        }
        public async Task Delete(string id)
        {
            var filter = Builders<ContentMain>.Filter.Eq(s => s.ContentMain_Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<ContentMain>> GetAll()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task Insert(ContentMain model)
        {
            await collection.InsertOneAsync(model);
        }

        public async Task Update(ContentMain model)
        {
            var filter = Builders<ContentMain>
                .Filter
                .Eq(s => s.ContentMain_Id, model.ContentMain_Id);
            await collection.ReplaceOneAsync(filter, model);
        }

        public async Task<ContentMain> GetById(string id)
        {
            return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
                .Result.FirstAsync();
        }
    }
}
