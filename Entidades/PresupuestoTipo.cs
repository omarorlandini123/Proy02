using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallePresupuesto
    {

        public int idPresupuestoTipo { get; set; }
        public Presupuesto presupuesto { get; set; }
        public TipoPresupuesto tipoPresupuesto { get; set; }
        public DateTime FechaReg { get; set; }
        public Usuario usuarioReg { get; set; }
        public DateTime UltModifReg { get; set; }
        public Usuario UltModifUser { get; set; }
        public DateTime fechaValIni { get; set; }
        public DateTime fechaValFin { get; set; }
        public double monto { get; set; }
        public Aprobacion.estados estadoActual { get; set; }
        public List<Aprobacion> aprobaciones { get; set; }
        public List<Version> versiones { get; set; }
        public int nroActual { get; set; }
        public List<DetalleVersion> detalleDeVersiones { get; set; }
    }
}
