using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AppV2.Models
{
    public class ViewPresupuestoArea
    {
        [Display(Name = "Presupuesto: ")]
        [DataType(DataType.Text)]
        public String nombreArea { get; set; }

        [Display(Name = "Código: ")]
        [DataType(DataType.Text)]
        public String codArea { get; set; }

        [Display(Name = "Desde: ")]
        [DataType(DataType.Text)]
        public String desde { get; set; }

        [Display(Name = "Hasta: ")]
        [DataType(DataType.Text)]
        public String hasta { get; set; }

        [Display(Name = "Version: ")]
        [DataType(DataType.Text)]
        public String version { get; set; }

        [Display(Name = "Fecha Reg: ")]
        [DataType(DataType.Text)]
        public String fecReg { get; set; }

        [Display(Name = "MontoTotal S/ ")]
        [DataType(DataType.Text)]
        public String montoTotal { get; set; }

        [Display(Name = "Aprobado por:")]
        [DataType(DataType.Text)]
        public String usu_apro { get; set; }

        public int anio { get; set; }
        public int idSede { get; set; }
        public int idArea { get; set; }
        public int idPresupuesto { get; set; }


    }
}