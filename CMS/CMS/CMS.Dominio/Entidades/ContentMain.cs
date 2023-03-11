using CMS.Dominio.Comunes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CMS.Dominio.Entidades
{
    public class ContentMain : FileClass
    {
        [BsonId]
        public ObjectId ContenMain_Id { get; set; }

        public string ContentMain_Pk { get; set; }

        public string ContentMain_Titulo { get; set; }

        public string ContentMain_Descripcion { get; set; }

        public int ContentMain_Estado { get; set; }

        public int ContentMain_Orden { get; set; }
    }
}
