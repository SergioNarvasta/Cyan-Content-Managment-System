using MongoDB.Bson;
using MongoDB.Driver;
using Personal.Models;

namespace Personal.Repositories
{
    public class ExperienceCollection : IExperienceCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Experience> Collection;

        public ExperienceCollection() 
        {
            Collection = _repository.db.GetCollection<Experience>("Experience");
        }
        public async Task DeleteExperience(string id)
        {
            var filter = Builders<Experience>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Experience>> GetAllExperience()
        {
           return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Project> GetProjectById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
                .Result.FirstAsync();
        }

        public async Task InsertProject(Project project)
        {
            await Collection.InsertOneAsync(project);
        }

        public async Task UpdateProject(Project project)
        {
            var filter = Builders<Project>
                .Filter
                .Eq(s => s.Id, project.Id);
            await Collection.ReplaceOneAsync(filter, project);
        }
    }
}
