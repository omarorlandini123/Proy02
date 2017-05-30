using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SubClase
    {

        public String codSubClase { get; set; }
        public String desSubClase { get; set; }
        /// <summary>
        /// La clase a la cual pertence la subclase
        /// </summary>
        public Clase clase { get; set; }

    }
}
