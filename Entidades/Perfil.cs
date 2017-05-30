using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perfil
    {

        public enum Estados {
            inactivo=0,
            activo
        }

        public int idPerfil { get; set; }
        public string nombre { get; set; }
        public Estados estado { get; set; }
        public List<Acceso> accesos { get; set; }
        public Perfil() {
            accesos = new List<Acceso>();
        }
    }
}
