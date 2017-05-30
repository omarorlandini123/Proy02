using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Archivo
    {

        public int idArchivo { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string ruta { get; set; }
        public DateTime fechaReg { get; set; }
        public Usuario UsuarioReg { get; set; }

    }
}
