using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Aprobacion
    {

        public enum estados {
            Desaprobado=0,
            Aprobado =1,
            Inactivo=2,
            Activo=3,
            Edicion=4,
            NoVerficiado=5,
            Enviado=6
        }
        public int idAprobacion { get; set; }
        public NivelAprobacion nivel { get; set; }
        public estados estado { get; set; }
        public Usuario usuarioApro { get; set; }
        public int orden { get; set; }
        public DateTime FechaApro { get; set; }
        public Usuario usuarioReg { get; set; }
        public DateTime FechaReg { get; set; }
        public string Observacion { get; set; }
        public Presupuesto presupAplica { get; set; }
        public DetallePresupuesto tipoPresup { get; set; }
        public Version version { get; set; }
        public DetalleVersion detalleVersion { get; set; }
        public bool listoParaAprobar { get; set; }
        public List<DetalleAprobacion> detalles { get; set; }
    }

    public class DetalleAprobacion {

        public DetalleAprobacion() { }
        public Aprobacion aprobacion { get; set; }
        public int idDetalleAprobacion { get; set; }
        public Aprobacion.estados estado { get; set; }
        public DateTime fecReg { get; set; }

    }
}
