using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Observacion
    {
        public int idObservacion { get; set; }
        public DetalleVersion detalle { get; set; }
        public string observacion { get; set; }
        public string observacionRes { get; set; }
        public Usuario usuarioReg { get; set; }
        public DateTime fechaReg { get; set; }
        public Usuario usuarioRes { get; set; }
        public DateTime fechaRes { set; get; }
        public bool isResuelta
        {
            get
            {
                return (usuarioRes != null && usuarioRes.idUsuario != "");              
            }
        }
        
    }
}
