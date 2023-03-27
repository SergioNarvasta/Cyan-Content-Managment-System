using CMS.Dominio.Entidades;
using CMS.Infraestructura.Data;
using CMS.Aplicacion.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CMS.Infraestructura.Repositorios
{
    public class AsideCollection : IAsideAppService
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private readonly IMongoCollection<Aside> collection;

        public AsideCollection()
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
