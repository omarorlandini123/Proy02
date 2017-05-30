using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AppV2.Models
{
    public class ViewPresupuestoGeneral
    {
        [Display(Name ="Presupuesto General ")]
        [DataType(DataType.Text)]
        public String anio { get; set; }

        [Display(Name = "Desde: ")]
        [DataType(DataType.Text)]
        public String  Desde { get; set; }

        [Display(Name = "Hasta: ")]
        [DataType(DataType.Text)]
        public String  Hasta { get; set; }

        [Display(Name = "Fecha Registro: ")]
        [DataType(DataType.Text)]
        public String fechaRegistro { get; set; }

        [Display(Name = "Aprobado por: ")]
        [DataType(DataType.Text)]
        public String AprobadoPor { get; set; }
        public String idSede { get; set; }

        public List<ViewPresupuestoArea> presupuestosArea { get; set; }
    }
}