using CMS.Dominio.Entidades;
using CMS.Infraestructura.Data;
using CMS.Aplicacion.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;

namespace SmartCMS.Infraestructure.Services
{
    public class PartnerCollection : IPartnerService
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private readonly IMongoCollection<Partner> collection;

        public PartnerCollection()
        {
            collection = _repository.db.GetCollection<Partner>("Partner");
        }
        public async Task Delete(string id)
        {
            var filter = Builders<Partner>.Filter.Eq(s => s.Partner_Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Partner>> GetAll()
        {
            //Filtrar campo estado
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task Insert(Partner model)
        {
            await collection.InsertOneAsync(model);
        }

        public async Task Update(Partner model)
        {
            var filter = Builders<Partner>
                .Filter
                .Eq(s => s.Partner_Id, model.Partner_Id);
            await collection.ReplaceOneAsync(filter, model);
        }

        public async Task<Partner> GetById(string id)
        {
            return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
                .Result.FirstAsync();
        }
    }
}
