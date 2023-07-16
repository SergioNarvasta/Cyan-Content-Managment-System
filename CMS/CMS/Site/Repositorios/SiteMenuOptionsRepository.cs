using MongoDB.Bson;
using MongoDB.Driver;
using Site.Models;
using Site.Interfaces;

namespace Site.Repositorios
{
	public class SiteMenuOptionsRepository : ISiteMenuOptionsRepository
	{
		internal MongoRepository _repository = new MongoRepository();

		public IMongoCollection<SiteMenuOptions> collection;
		public SiteMenuOptionsRepository() {
			collection = _repository.database.GetCollection<SiteMenuOptions>("SiteMenuOptions");
		}

		public async Task<IEnumerable<SiteMenuOptions>> ListaMenuOpciones()
		{
			var list = await collection.FindAsync(new BsonDocument())
				       .Result.ToListAsync();
			return list;
		}
	}
}
