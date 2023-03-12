using CMS.Dominio.Entidades;
using CMS.Infraestructura.Data;
using CMS.Aplicacion.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CMS.Infraestructura.Repositorios
{
    public class SliderMainCollection : ISliderMainAppService
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<SliderMain> collection;

        public SliderMainCollection()
        {
            collection = _repository.db.GetCollection<SliderMain>("SliderMain");
        }
        public async Task DeleteSliderMain(string id)
        {
            var filter = Builders<SliderMain>.Filter.Eq(s => s.SliderMain_Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<SliderMain>> GetAllSliderMain()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task InsertSliderMain(SliderMain contentmain)
        {
            await collection.InsertOneAsync(contentmain);
        }

        public async Task UpdateSliderMain(SliderMain contentmain)
        {
            var filter = Builders<SliderMain>
                .Filter
                .Eq(s => s.SliderMain_Id, contentmain.SliderMain_Id);
            await collection.ReplaceOneAsync(filter, contentmain);
        }

		public async Task<SliderMain> GetSliderMainById(string id)
		{
			return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
				.Result.FirstAsync();
		}
	}
}
