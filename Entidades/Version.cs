using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Version
    {

        public int idVersion { get; set; }
        public int numeroVersion { get; set; }
        public DetallePresupuesto presupuestoTipo {get;set;}
        public Area area { get; set; }
        public DateTime fechaReg { get; set; }
        public Usuario usuarioReg { get; set; }
        public DateTime UltModifFec { get; set; }
        public Usuario UltModifUser { get; set; }
        public DateTime fechaValIni { get; set; }
        public DateTime fechaValFin { get; set; }
        public double monto { get; set; }
        public Aprobacion.estados estadoActual { get; set; }
        public List<Aprobacion> aprobaciones { get; set; }
        public List<DetalleVersion> detalles { get; set; }


    }
}
