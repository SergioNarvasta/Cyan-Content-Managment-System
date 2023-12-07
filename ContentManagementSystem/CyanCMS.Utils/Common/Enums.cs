
using System.ComponentModel.DataAnnotations;

namespace Utils
{
    public class Enums
    {
        public enum Status
        {
            [Display(Name = "Activo")]
            Active = 1,
            [Display(Name = "Inactivo")]
            Inactive = 0
        }
        public enum ComponentType
        {
            MenuOption = 1,
            SliderMain = 2,
            ContentMain= 3,
            ContentSec = 4,
            Aside      = 5,
            SliderSmall= 6,
            SliderSec  = 7,
            Partner    = 8
        }

        public static string GetComponentDescription(int componentType) =>
          componentType switch
            {
               1 => "Menu de Opciones : Barra de menu de opciones",
               2 => "Slider Principal : Primer slider",
               3 => "Contenido Principal : Se muestra al inicio",
               4 => "Contenido Secundario : Se muestra seguido del principal",
               5 => "Contenido Direccional Derecha: Se muestra a la derecha de contenido principal",
               6 => "Slider pequeño: Se puede utilizar como slider y como listado de items",
               7 => "Slider Secundario : Se puede mostrar informacion adicional",
               8 => "Partners: Se puede mostrar informacion de socios, clientes u otros",
               _ => " " 
            };
        public enum ComponentStyle
        {
            [Display(Name = "Rectangulo")]
            Rectangle = 1,
            [Display(Name = "Ovalo")]
            Oval = 2,
            
        }
    }
}
