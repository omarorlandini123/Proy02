using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Procedimiento
    {

        public String nombre { get; set; }
        public List<Parametro> parametros { get; set; }

        public Procedimiento() {
            parametros = new List<Parametro>();
        }

    }
}
