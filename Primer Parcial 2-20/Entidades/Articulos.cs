using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Primer_Parcial_2_20.Entidades
{
   public class Articulos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int Existecia { get; set; }
        public int Costo { get; set; }
        public int Valorinvetario { get; set; }
    } 
}
