
using MongoDB.Bson;
using MongoDB.Driver;
using Site.Interfaces;
using Site.Models;

namespace Site.Repositorios
{
    public class SliderMainRepository  : ISliderMainRepository
    {
        internal MongoRepository _repository = new MongoRepository();

        private readonly IMongoCollection<SliderMain> collection;

        public SliderMainRepository() 
        {
            collection = _repository.database.GetCollection<SliderMain>("SliderMain");
        }

        public async Task<IEnumerable<SliderMain>> Listado() 
        {
            var list = await collection.FindAsync(new BsonDocument())
                       .Result.ToListAsync();
            return list;
        }
        public async Task<IEnumerable<SliderMain>> GetByCompanyPk(string company_Pk)
        {
            return await collection.FindAsync(new BsonDocument
               { { "Company_Pk", company_Pk } })
                .Result.ToListAsync();
        }
    }
}
