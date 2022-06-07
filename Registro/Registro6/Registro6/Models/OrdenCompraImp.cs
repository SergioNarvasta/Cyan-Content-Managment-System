using System.ComponentModel.DataAnnotations;

namespace Registro6.Models
{
    public class OrdenCompraImp
    {
        [Key]
        public int IdOrdenCompraImp { get; set; }

        [Display(Name = "TipoOrdenCompra")]
        [Required(ErrorMessage = "Debe de ingresar el TipoOCompra")]
        [MaxLength(13, ErrorMessage = "El campo no debe de tener mas de 13 caracteres")]
        public string TipoOCompra { get; set; }

        [Display(Name = "NroOrdenCompra")]
        [Required(ErrorMessage = "Debe de ingresar NroOCompra")]
        [MaxLength(12, ErrorMessage = "El campo no debe de tener mas de 12 caracteres")]
        public int NroOCompra { get; set; }

        public DateTime Fecha { get; set; }
        public float TipoCambio { get; set; }

        [Required(ErrorMessage = "Debe Seleccionar Estado")]
        [MaxLength(12, ErrorMessage = "El campo no debe de tener mas de 12 caracteres")]
        public String Estado { get; set; }

        [Display(Name = "CodigoInterno")]
        public int CodInterno { get; set; }

        [Display(Name = "CotizacionVenta")]
        [Required(ErrorMessage = "Debe de ingresar el CodCotizacion")]
        [MaxLength(13, ErrorMessage = "El campo no debe de tener mas de 13 caracteres")]
        public int CodCotizacion { get; set; }

        [Required(ErrorMessage = "Debe de ingresar Proveedor")]
        [MaxLength(12, ErrorMessage = "El campo no debe de tener mas de 12 caracteres")]
        public String Proveedor { get; set; }

        [Required(ErrorMessage = "Debe de ingresar el Contacto")]
        [MaxLength(15, ErrorMessage = "El campo no debe de tener mas de 15 caracteres")]
        public String Contacto { get; set; }

        [Required(ErrorMessage = "Debe de ingresar Area")]
        [MaxLength(12, ErrorMessage = "El campo no debe de tener mas de 12 caracteres")]
        public String Area { get; set; }

        [Required(ErrorMessage = "Debe de ingresar Dato")]
        [MaxLength(12, ErrorMessage = "El campo no debe de tener mas de 12 caracteres")]
        public String TipoCompra { get; set; }

        [Required(ErrorMessage = "Debe de ingresar Dato")]
        [MaxLength(18, ErrorMessage = "No debe de tener mas de 18 caracteres")]
        public String CondicionPago { get; set; }
    }
}
