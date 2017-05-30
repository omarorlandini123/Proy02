using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AppV2.Models
{
    public class ViewModelAgregarItem
    {
        [Key]
        [Display(Name = "Código")]
        public int codDetalle { get; set; }

        [Display(Name = "Cod. Material")]
        [DataType(DataType.Text)]
        public String codMaterial { get; set; }

        [Display(Name = "Desc. Material")]
        [DataType(DataType.Text)]
        public String desMaterial { get; set; }

        [Display(Name = "Clase")]
        [DataType(DataType.Text)]
        public String desClase { get; set; }

        [Display(Name = "Sub Clase")]
        [DataType(DataType.Text)]
        public String desSubClase { get; set; }

        [Display(Name = "Precio Unit")]
        [DataType(DataType.Text)]
        public Double precioUnit { get; set; }

        [Display(Name = "Unidad")]
        [DataType(DataType.Text)]
        public String unidadMedida { get; set; }

        [Display(Name = "Cantidad")]
        [DataType(DataType.Text)]
        public Double Cantidad { get; set; }

        [Display(Name = "Criticidad")]
        [DataType(DataType.Text)]
        public int criticidad { get; set; }

        [Display(Name = "Prioridad")]
        [DataType(DataType.Text)]
        public int prioridad { get; set; }

        [Display(Name = "Sustento")]
        [DataType(DataType.Text)]
        public String sustento { get; set; }

        [Display(Name = "Total")]
        [DataType(DataType.Text)]
        public Double total { get; set; }

        [Display(Name = "Largo")]
        [DataType(DataType.Text)]
        public Double largo { get; set; }

        [Display(Name = "Ancho")]
        [DataType(DataType.Text)]
        public Double ancho { get; set; }

        [Display(Name = "Alto")]
        [DataType(DataType.Text)]
        public Double alto { get; set; }

        [Display(Name = "Fec. Solicitud")]
        [DataType(DataType.Date)]
        public DateTime fecSoli { get; set; }

        [Display(Name = "Fec. Entrega")]
        [DataType(DataType.Date)]
        public DateTime fecEnt { get; set; }


    }
}