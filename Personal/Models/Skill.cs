namespace Personal.Models
{
    public class Class
    {
       [BsonId]
        public ObjectId Id { get; set; }

        public string Nombre { get; set; }

        public string Version {get; set;}

        public image Icono {}
    }
}