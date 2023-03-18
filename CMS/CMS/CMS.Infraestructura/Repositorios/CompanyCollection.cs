using CMS.Dominio.Entidades;
using CMS.Infraestructura.Data;
using CMS.Aplicacion.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CMS.Infraestructura.Repositorios
{
    public class CompanyCollection : ICompanyAppService
	{
        internal MongoDBRepository _repository = new MongoDBRepository();
        private readonly IMongoCollection<Company> collection;

        public CompanyCollection()
        {
            collection = _repository.db.GetCollection<Company>("Company");
        }
        public async Task DeleteCompany(string id)
        {
            var filter = Builders<Company>.Filter.Eq(s => s.Company_Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Company>> GetAllCompany()
        {
            return await collection.FindAsync(new BsonDocument{ { "Company_Estado", 1 } }
                ).Result.ToListAsync();
        }

        public async Task InsertCompany(Company company)
        {
            await collection.InsertOneAsync(company);
        }

        public async Task UpdateCompany(Company company)
        {
            var filter = Builders<Company>
                .Filter
                .Eq(s => s.Company_Id, company.Company_Id);
            await collection.ReplaceOneAsync(filter, company);
        }

		public async Task<Company> GetCompanyById(string id)
		{
			return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
				.Result.FirstAsync();
		}
	}
}
