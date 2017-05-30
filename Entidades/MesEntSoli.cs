using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MesEntSoli
    {

        public enum Meses
        {
            Enero=1, Febrero, Marzo,
            Abril, Mayo, Junio,
            Julio,Agosto,Setiembre,Octubre,
            Noviembre,Diciembre
        }

        public enum Tipos
        {
            Solicitud = 0,
            Entrega =1        
        }

        public static string getMesCorto(Meses Mese)
        {
            string rpta = "Sin mes";
            switch (Mese) {
                case Meses.Enero:
                    rpta = "Ene";
                    break;
                case Meses.Febrero:
                    rpta = "Feb";
                    break;
                case Meses.Marzo:
                    rpta = "Mar";
                    break;
                case Meses.Abril:
                    rpta = "Abr";
                    break;
                case Meses.Mayo:
                    rpta = "May";
                    break;
                case Meses.Junio:
                    rpta = "Jun";
                    break;
                case Meses.Julio:
                    rpta = "Jul";
                    break;
                case Meses.Agosto:
                    rpta = "Ago";
                    break;
                case Meses.Setiembre:
                    rpta = "Set";
                    break;
                case Meses.Octubre:
                    rpta = "Oct";
                    break;
                case Meses.Noviembre:
                    rpta = "Nov";
                    break;
                case Meses.Diciembre:
                    rpta = "Dic";
                    break;

            }
            return rpta;


        }
       

        public int idMesEntSoli { get; set; }
        public DetalleVersion detalle { get; set; }
        public Meses Mes { get; set; }
        public DateTime fechaReg { get; set; }
        public Usuario usuarioReg { get; set; }
        public Tipos tipo { get; set; }
    }

    
}
