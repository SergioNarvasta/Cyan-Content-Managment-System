
using MongoDB.Bson;
using MongoDB.Driver;
using Site.Interfaces;
using Site.Models;

namespace Site.Repositorios
{
    public class SliderMainRepository  : ISliderMainRepository
    {
        internal MongoRepository _repository = new MongoRepository();

        private IMongoCollection<SliderMain> collection;

        public SliderMainRepository() 
        {
            collection = _repository.database.GetCollection<SliderMain>("SliderMain");
        }

        public async Task<IEnumerable<SliderMain>> Listado() 
        {
          return await collection.FindAsync( new BsonDocument()).Result.ToListAsync();
        }



    }
}
