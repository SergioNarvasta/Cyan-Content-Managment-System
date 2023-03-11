using CMS.Dominio.Entidades;
using CMS.Dominio.Interfaces.Repositorios;
using CMS.Infraestructura.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CMS.Infraestructura.Repositorios
{
    public class SliderMainCollection : ISliderMainRepository
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<SliderMain> Collection;

        public SliderMainCollection()
        {
            Collection = _repository.db.GetCollection<SliderMain>("SliderMain");
        }
        public async Task DeleteSliderMain(string id)
        {
            var filter = Builders<SliderMain>.Filter.Eq(s => s.ContenMain_Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<SliderMain>> GetAllSliderMain()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task InsertSliderMain(SliderMain contentmain)
        {
            await Collection.InsertOneAsync(contentmain);
        }

        public async Task UpdateSliderMain(SliderMain contentmain)
        {
            var filter = Builders<SliderMain>
                .Filter
                .Eq(s => s.ContenMain_Id, contentmain.ContenMain_Id);
            await Collection.ReplaceOneAsync(filter, contentmain);
        }
    }
}
