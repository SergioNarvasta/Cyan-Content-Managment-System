using CMS.Dominio.Entidades;
using CMS.Infraestructura.Data;
using CMS.Aplicacion.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Domain.Entities;

namespace SmartCMS.Infraestructure.Services
{
    public class SliderMainService : ISliderMainService
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private readonly IMongoCollection<SliderMain> collection;

        public SliderMainService()
        {
            collection = _repository.db.GetCollection<SliderMain>("SliderMain");
        }
        public async Task Delete(string id)
        {
            var filter = Builders<SliderMain>.Filter.Eq(s => s.SliderMain_Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<SliderMain>> GetAll()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task Insert(SliderMain contentmain)
        {
            await collection.InsertOneAsync(contentmain);
        }

        public async Task Update(SliderMain contentmain)
        {
            var filter = Builders<SliderMain>
                .Filter
                .Eq(s => s.SliderMain_Id, contentmain.SliderMain_Id);
            await collection.ReplaceOneAsync(filter, contentmain);
        }

        public async Task<SliderMain> GetById(string id)
        {
            return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
                .Result.FirstAsync();
        }
    }
}
