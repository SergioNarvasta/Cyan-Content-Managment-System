
using MongoDB.Driver;

namespace Site.Repositorios
{
    public class MongoRepository
    {
        public MongoClient mongoclient;
        public IMongoDatabase database;

        public MongoRepository()
        {
            mongoclient = new MongoClient("mongodb+srv://Sergio:<0024>@cluster0.3neun83.mongodb.net/");
            database = mongoclient.GetDatabase("SampleCMS_Dev");

        }
    }
}
