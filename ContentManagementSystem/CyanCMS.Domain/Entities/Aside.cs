using MongoDB.Bson;
using CMS.Dominio.Comunes;
using MongoDB.Bson.Serialization.Attributes;

namespace CMS.Dominio.Entidades
{
    public class Aside :FileUnit
    {
        [BsonId]
        public ObjectId Aside_Id { get; set; }

        public string Aside_Pk { get; set; }

        public string Aside_Titulo { get; set; }

        public string Aside_Descripcion { get; set; }
        public string Aside_Contenido { get; set; }

        public int Aside_Estado { get; set; }

        public int Aside_Orden { get; set; }
        public string Company_Pk { get; set; }
    }
}
