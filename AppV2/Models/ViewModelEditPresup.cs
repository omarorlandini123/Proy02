using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace AppV2.Models
{
    public class ViewModelEditPresup
    {
        [Display(Name = "Detalle Presupuesto: ")]
        public String nombrePresup { get; set; }
        public ViewDetallePresup Detalle { get; set; }

    }
}