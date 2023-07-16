
using MongoDB.Driver;

namespace Site.Repositorios
{
    public class MongoRepository
    {
        public MongoClient mongoclient;
        public IMongoDatabase database;

        public MongoRepository()
        {
            mongoclient = new MongoClient("mongodb+srv://s76325953:s76325953@cluster0.acwg8vw.mongodb.net/test");
            database = mongoclient.GetDatabase("CMS_Dev");

        }
    }
}
