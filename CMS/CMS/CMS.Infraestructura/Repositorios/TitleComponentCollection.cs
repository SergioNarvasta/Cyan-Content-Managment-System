using CMS.Dominio.Entidades;
using CMS.Infraestructura.Data;
using CMS.Aplicacion.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CMS.Infraestructura.Repositorios
{
    public class TitleComponentCollection : ITitleComponentService
	{
        internal MongoDBRepository _repository = new MongoDBRepository();
        private readonly IMongoCollection<TitleComponent> collection;

        public TitleComponentCollection()
        {
            collection = _repository.db.GetCollection<TitleComponent>("TitleComponent");
        }
        public async Task Delete(string id)
        {
            var filter = Builders<TitleComponent>.Filter.Eq(s => s.TitleComponent_Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<TitleComponent>> GetAll()
        {
            //Filtrar campo estado
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task Insert(TitleComponent model)
        {
            await collection.InsertOneAsync(model);
        }

        public async Task Update(TitleComponent model)
        {
            var filter = Builders<TitleComponent>
                .Filter
                .Eq(s => s.TitleComponent_Id, model.TitleComponent_Id);
            await collection.ReplaceOneAsync(filter, model);
        }

		public async Task<TitleComponent> GetById(string id)
		{
			return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
				.Result.FirstAsync();
		}
	}
}
