using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clase
    {

        public String codClase { get; set; }
        public String desClase { get; set; }
        /// <summary>
        /// Lista las subClases de esta clase
        /// </summary>
        public List<SubClase> subClases { get; set; }

    }
}
