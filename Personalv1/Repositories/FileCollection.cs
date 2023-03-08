using MongoDB.Bson;
using MongoDB.Driver;
using Personal.Models;
using Personal.Data;
using Personal.Interfaces;

namespace Personal.Repositories
{
    public class FileCollection : IFileCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<FileClass> Collection;

        public FileCollection()
        {
            Collection = _repository.db.GetCollection<FileClass>("File");
        }
        public async Task InsertFile(FileClass file)
        {
            await Collection.InsertOneAsync(file);
        }
        public Task DeleteFile(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FileClass>> GetAllFiles()
        {
            throw new NotImplementedException();
        }

        public Task<FileClass> GetFileById(string id)
        {
            throw new NotImplementedException();
        }

        

        public Task UpdateFile(FileClass file)
        {
            throw new NotImplementedException();
        }
    }
}
