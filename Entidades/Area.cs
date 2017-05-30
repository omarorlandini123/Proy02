using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Area
    {

        public String codArea { get; set; }
        public String desArea { get; set; }
        public Sede sede { get; set; } // la sede a la que el área pertenece
        public List<Usuario> usuariosArea { get; set; } // Usuarios del área
        public List<Version> versiones { get; set; } // Los presupuestos (versiones) que tiene el área
        public List<Presupuesto> presupuestos { get; set; }
        public Area() {
            usuariosArea = new List<Usuario>();
            versiones = new List<Version>();
            presupuestos = new List<Presupuesto>();
        }
    }
}
