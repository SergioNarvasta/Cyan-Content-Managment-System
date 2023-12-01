

using CyanCMS.Domain.Common;

namespace CMS.Dominio.Common
{
    public class FileUnit : Audit
    {
        public string File_Nombre { get; set; }

        public string File_Base64 { get; set;}

        public string File_Tamanio { get;set;}
    }
}
