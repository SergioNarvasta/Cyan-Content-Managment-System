using CMS.Dominio.Entidades;
using CMS.Dominio.Interfaces.Repositorios;
using CMS.Infraestructura.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CMS.Infraestructura.Repositorios
{
    public class ContentMainCollection : IContentMainRepository
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<ContentMain> Collection;

        public ContentMainCollection()
        {
            Collection = _repository.db.GetCollection<ContentMain>("ContentMain");
        }
        public async Task DeleteContentMain(string id)
        {
            var filter = Builders<ContentMain>.Filter.Eq(s => s.ContenMain_Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<ContentMain>> GetAllContentMain()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task InsertContentMain(ContentMain contentmain)
        {
            await Collection.InsertOneAsync(contentmain);
        }

        public async Task UpdateContentMain(ContentMain contentmain)
        {
            var filter = Builders<ContentMain>
                .Filter
                .Eq(s => s.ContenMain_Id, contentmain.ContenMain_Id);
            await Collection.ReplaceOneAsync(filter, contentmain);
        }
    }
}
