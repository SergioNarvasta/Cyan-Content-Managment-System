

namespace Site.Models.Comunes
{
    public class FileClass : Audit
    {
        public string File_Nombre { get; set; }

        public string File_NombreF { get; set; }
        public string File_Base64F { get; set; }
        public string File_TamanioF { get; set; }
        public string File_NombreS { get; set; }
        public string File_Base64S { get; set; }
        public string File_TamanioS { get; set; }
        public string File_NombreT { get; set; }
        public string File_Base64T { get; set; }
        public string File_TamanioT { get; set; }
    }
}
