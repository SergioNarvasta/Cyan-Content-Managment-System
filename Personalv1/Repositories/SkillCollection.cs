using MongoDB.Bson;
using MongoDB.Driver;
using Personal.Models;
using Personal.Data;
using Personal.Interfaces;

namespace Personal.Repositories
{
    public class SkillCollection : ISkillCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Skill> Collection;

        public SkillCollection()
        {
            Collection = _repository.db.GetCollection<Skill>("Skill");
        }

        public async Task InsertSkill(Skill skill)
        {
            await Collection.InsertOneAsync(skill);
        }
        public Task DeleteFile(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Skill>> GetAllSkills()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        
    }
}
