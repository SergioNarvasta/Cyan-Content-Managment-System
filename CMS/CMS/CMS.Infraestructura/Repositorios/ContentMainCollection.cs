using CMS.Dominio.Entidades;
using CMS.Infraestructura.Data;
using CMS.Aplicacion.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CMS.Infraestructura.Repositorios
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

        public async Task Insert(ContentMain contentmain)
        {
            await collection.InsertOneAsync(contentmain);
        }

        public async Task Update(ContentMain contentmain)
        {
            var filter = Builders<ContentMain>
                .Filter
                .Eq(s => s.ContentMain_Id, contentmain.ContentMain_Id);
            await collection.ReplaceOneAsync(filter, contentmain);
        }

		public async Task<ContentMain> GetById(string id)
		{
			return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
				.Result.FirstAsync();
		}
	}
}
