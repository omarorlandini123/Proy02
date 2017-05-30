using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AppV2.Models
{
    public class ViewDetallePresup
    {

        [Key]
        [Display(Name ="id")]
        public int idDetalle { get; set; }

        [Display(Name ="Estado")]
        [DataType(DataType.Text)]
        public String estado { get; set; }

        [Display(Name = "Codigo Mat")]
        [DataType(DataType.Text)]
        public String codigoMaterial { get; set; }

        [Display(Name = "Descripción Mat.")]
        [DataType(DataType.Text)]
        public String descMaterial { get; set; }

        [Display(Name = "Clase")]
        [DataType(DataType.Text)]
        public String Clase { get; set; }

        [Display(Name = "Sub Clase")]
        [DataType(DataType.Text)]
        public String subClase { get; set; }

        [Display(Name = "Precio Unit.")]
        [DataType(DataType.Text)]
        public Double precioUnit { get; set; }

        [Display(Name = "Unid. Medida")]
        [DataType(DataType.Text)]
        public String unidadMedida { get; set; }

        [Display(Name = "Cantidad")]
        [DataType(DataType.Text)]
        public Double cantidad { get; set; }

        [Display(Name = "Unidad Solicitada")]
        [DataType(DataType.Text)]
        public String UnidadSoli { get; set; }

        [Display(Name = "Criticidad")]
        [DataType(DataType.Text)]
        public int criticidad { get; set; }

        [Display(Name = "Prioridad")]
        [DataType(DataType.Text)]
        public int prioridad { get; set; }

        [Display(Name = "Total")]
        [DataType(DataType.Text)]
        public Double Total { get; set; }

        [Display(Name = "Largo")]
        [DataType(DataType.Text)]
        public Double largo { get; set; }

        [Display(Name = "Ancho")]
        [DataType(DataType.Text)]
        public Double ancho { get; set; }

        [Display(Name = "Alto")]
        [DataType(DataType.Text)]
        public Double alto { get; set; }

        [Display(Name = "Sustento")]
        [DataType(DataType.Text)]
        public String sustento { get; set; }

        [Display(Name = "Mes Solicitud")]
        [DataType(DataType.Text)]
        public String mesSoliText { get {
                return mesSolicitud.ToShortDateString();
            } }

        [Display(Name = "Mes Entrega")]
        [DataType(DataType.Text)]
        public String mesEntText
        {
            get
            {
                return mesEntrega.ToShortDateString();
            }
        }

        [Display(Name = "Mes Solicitud")]
        [DataType(DataType.DateTime)]
        public DateTime mesSolicitud { get; set; }

        [Display(Name = "Mes Entrega")]
        [DataType(DataType.DateTime)]
        public DateTime mesEntrega { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.Text)]
        public String Observacion { get; set; }


    }
}