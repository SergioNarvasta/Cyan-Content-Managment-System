using CMS.Dominio.Common;
using CyanCMS.Domain.Common;
using MongoDB.Bson;

using MongoDB.Bson.Serialization.Attributes;

namespace CyanCMS.Domain.Entities
{
    public class Partner : FileUnit
    {
        [BsonId]
        public ObjectId Partner_Id { get; set; }

        public string Partner_Pk { get; set; }

        public string Partner_Nombre { get; set; }

        public string Partner_Descripcion { get; set; }

        public int Partner_Estado { get; set; }

        public int Partner_Orden { get; set; }
        public string Company_Pk { get; set; }
    }
}
