

namespace CMS.Dominio.Comunes
{
    public class FileClass : Audit
    {
        public string File_Nombre { get; set; }

        public string File_RutaArchivo { get; set; }

        public string File_RutaDrive { get; set; }

        //public IFormFile File_Archivo { get; set; }

        public string File_Base64 { get; set; }

        public string File_Tamanio { get; set; }

        public string File_Extension { get; set; }
    }
}
