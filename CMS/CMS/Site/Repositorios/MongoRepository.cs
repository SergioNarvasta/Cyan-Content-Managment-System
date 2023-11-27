
using MongoDB.Driver;

namespace Site.Repositorios
{
    public class MongoRepository
    {
        public MongoClient mongoclient;
        public IMongoDatabase database;

        public MongoRepository()
        {
            mongoclient = new MongoClient("mongodb+srv://sergio:<password>@itcyandb.d0wzskg.mongodb.net/");
            database = mongoclient.GetDatabase("ITCyan_SmartCMS_Dev");

        }
    }
}
