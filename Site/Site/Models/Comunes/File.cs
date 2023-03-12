

namespace CMS.Dominio.Comunes
{
    public class FileClass : Audit
    {
        public string File_Nombre { get; set; }

        public string File_RutaArchivo { get; set; } //Opcional solo si se guarta en ruta fisica

        public string File_RutaDrive { get; set; }   //Opcional si carga desde google drive

        //public IFormFile File_Archivo { get; set; }  En caso de registrar archivo en ruta fisica

        public string File_Base64 { get; set; }

        public string File_Tamanio { get; set; }

        public string File_Extension { get; set; }
    }
}
