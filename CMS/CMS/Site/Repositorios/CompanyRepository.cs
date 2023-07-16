using Site.Models;
using Site.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Site.Repositorios
{
    public class CompanyRepository : ICompanyRepository
	{
        internal MongoRepository _repository = new MongoRepository();
        private readonly IMongoCollection<Company> collection;

        public CompanyRepository()
        {
            collection = _repository.database.GetCollection<Company>("Company");
        }
        public async Task Delete(string id)
        {
            var filter = Builders<Company>.Filter.Eq(s => s.Company_Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await collection.FindAsync(new BsonDocument{ { "Company_Estado", 1 } }
                ).Result.ToListAsync();
        }

        public async Task Insert(Company model)
        {
            await collection.InsertOneAsync(model);
        }

        public async Task Update(Company model)
        {
            var filter = Builders<Company>
                .Filter
                .Eq(s => s.Company_Id, model.Company_Id);
            await collection.ReplaceOneAsync(filter, model);
        }

		public async Task<Company> GetById(string User_Pk)
		{
			return await collection.FindAsync(new BsonDocument { { "User_Pk", User_Pk } })
				.Result.FirstOrDefaultAsync();
		}
		public async Task<IEnumerable<Company>> GetByCompanyPk(string company_Pk)
		{
			return await collection.FindAsync(new BsonDocument 
            { { "Company_Pk", company_Pk } })
				.Result.ToListAsync();
		}
	}
}
