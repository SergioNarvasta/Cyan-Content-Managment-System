
using CMS.Dominio.Comunes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CMS.Dominio.Entidades
{
    public class FileCreate : Audit
    {
        [BsonId]
        public ObjectId Archivo_Id { get; set; }
        public string Archivo_Pk { get; set; }
        public string  Archivo_Nombre     {get;set;}       
        public string  Archivo_Extension  {get;set;}   
        public double  Archivo_Tamanio    {get;set;}      
        public string  Archivo_Ubicacion  {get;set;}  
        public int     Archivo_Estado     {get;set;}   
        public string  Archivo_Base64     {get;set;} 

          
    }
}