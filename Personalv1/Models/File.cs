using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Personal.Models
{
    public class FileClass
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public IFormFile Archivo { get; set; }

    }
}
