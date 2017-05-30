using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Material
    {

        public String codProducto { get; set; }
        public String desc { get; set; }
        public Double precioUnit { get; set; }
        /// <summary>
        /// Lista los detalles de presupuesto que contienen este material
        /// </summary>
        public List<DetalleVersion> detallesPresup { get; set; }
        /// <summary>
        /// La unidad actual de este material
        /// </summary>
        public string unidad { get; set; }
        /// <summary>
        /// La sub clase a la cual pertenece este material
        /// </summary>
        public SubClase subClase { get; set; }
        public Material() {
            detallesPresup = new List<DetalleVersion>();
        } 

    }
}
