
using CyanCMS.Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CyanCMS.Domain.Entities
{
    public class ContentSec :FileUnit
    {
        [BsonId]
        public ObjectId ContentSec_Id { get; set; }

        public string ContentSec_Pk { get; set; }

        public string ContentSec_Titulo { get; set; }

        public string ContentSec_Descripcion { get; set; }
        public string ContentSec_Contenido { get; set; }

        public int ContentSec_Estado { get; set; }

        public int ContentSec_Orden { get; set; }
        public string Company_Pk { get; set; }
    }
}
