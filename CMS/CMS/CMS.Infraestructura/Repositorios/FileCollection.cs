using MongoDB.Bson;
using MongoDB.Driver;


namespace CMS.Infraestructura.Repositorios
{
    public class FileCollection : IFileCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<FileCreate> Collection;

        public FileCollection()
        {
            Collection = _repository.db.GetCollection<FileCreate>("File");
        }
        public async Task InsertFile(FileCreate file)
        {
            await Collection.InsertOneAsync(file);
        }
        public Task DeleteFile(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FileCreate>> GetAllFiles()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
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
