using MongoDB.Driver;

namespace CMS.Infraestructura.Data
{
    public class MongoDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository(){
            client = new MongoClient("mongodb+srv://sergio:<password>@itcyandb.d0wzskg.mongodb.net/");
            db = client.GetDatabase("CyanCMSDb_Dev");
        }
    }
}
