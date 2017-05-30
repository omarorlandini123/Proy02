using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Acceso
    {


        public Accesos codigo { get; set; }
        public string descripcion { get; set; }
        public Perfil perfil { get; set; }
        public List<Perfil> perfilesAcceso { get; set; }
        public Acceso() {
            perfilesAcceso = new List<Perfil>();

        }


    }
}
