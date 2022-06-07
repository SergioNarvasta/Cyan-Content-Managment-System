using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIObject.Models
{
    public class OrdenCompraImp
    {
        [Key]
        public int IdOrdenCompraImp { get; set; }

        [Display(Name = "TipoOCompra")]
        [Required(ErrorMessage = "Debe de ingresar el TipoOCompra")]
        [MaxLength(10, ErrorMessage = "El campo no debe de tener mas de 20 caracteres")]
        public string TipoOCompra { get; set; }

        [Display(Name = "NroOCompra")]
        [Required(ErrorMessage = "Debe de ingresar NroOCompra")]
        [MaxLength(80, ErrorMessage = "El campo no debe de tener mas de 12 caracteres")]
        public int NroOCompra { get; set; }
    
        public DateTime Fecha { get; set; }

        [Display(Name = "TipoOCompra")]
        [Required(ErrorMessage = "Debe de ingresar el TipoOCompra")]
        [MaxLength(10, ErrorMessage = "El campo no debe de tener mas de 20 caracteres")]
        public string TipoOCompra { get; set; }

        [Display(Name = "NroOCompra")]
        [Required(ErrorMessage = "Debe de ingresar NroOCompra")]
        [MaxLength(80, ErrorMessage = "El campo no debe de tener mas de 12 caracteres")]
        public int NroOCompra { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Debe de ingresar la direccion del proveedor")]
        [MaxLength(100, ErrorMessage = "El campo no debe de tener mas de 100 caracteres")]
        public string Direccion { get; set; }










        //public virtual ICollection<OrdenCompraDet> OrdenCompraDet { get; set; }  //Relacionar entidades
    }
}
