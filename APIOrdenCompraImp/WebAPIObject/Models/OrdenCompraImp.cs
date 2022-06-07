using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIObject.Models
{
    public class OrdenCompraImp
    {
        [Key]
        public int IdOrdenCompraCab { get; set; }

        [Display(Name = "RUC")]
        [Required(ErrorMessage = "Debe de ingresar el RUC de la empresa")]
        [MaxLength(10, ErrorMessage = "El campo no debe de tener mas de 10 caracteres")]
        public string RUC { get; set; }

        [Display(Name = "Razon Social")]
        [Required(ErrorMessage = "Debe de ingrear la razon social del Proveedor")]
        [MaxLength(80, ErrorMessage = "El campo no debe de tener mas de 80 caracteres")]
        public string RazonSocial { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Debe de ingresar la direccion del proveedor")]
        [MaxLength(100, ErrorMessage = "El campo no debe de tener mas de 100 caracteres")]
        public string Direccion { get; set; }

        public virtual ICollection<OrdenCompraDet> OrdenCompraDet { get; set; }  //Para relacionar entidades
    }
}
