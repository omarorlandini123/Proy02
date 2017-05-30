using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Entidades
{
    public class Usuario
    {
        public string idUsuario { get; set; }
        [Display(Name = "Usuario")]
        [Required]
        [DataType(DataType.Text)]
        public String usuario { get; set; }
        [Display(Name = "Contraseña")]
        [Required]
        [DataType(DataType.Password)]
        public String password { get; set; }
        public String Nombres { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        /// <summary>
        /// Representa el área a la cual pertenece el usuario
        /// </summary>
        public Area area { get; set; } 
        /// <summary>
        /// lista los presupuestos que ha aperturado el usuario
        /// </summary>
        public List<Presupuesto> presupAper { get; set; }
        /// <summary>
        /// Lista los presupuestos que ha aprobado el usuario 
        /// </summary>
        public List<Presupuesto> presupAprob { get; set; }
        /// <summary>
        /// Lista los niveles de aprobacion que tiene el usuario
        /// </summary>
        public List<NivelAprobacion> nivelesAprobacion { get; set; }
        public List<Perfil> perfiles { get; set; }
        public string numeroPersonal { get; set; }
        public CentroCosto centroCosto { get; set; }
        public GrupoCentroCosto grupoCentroCosto { get; set; }

        public bool tieneAccesoA(Accesos acc) {
            if (perfiles != null)
            {
                foreach (Perfil per in perfiles)
                {
                    if (per.accesos != null)
                    {
                        foreach (Acceso acces in per.accesos)
                        {
                            if (acces.codigo == acc)
                            {
                                return true;
                            }

                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// List los detalles de presupuesto que han sido creados por el usuario
        /// </summary>

        public Usuario() {
            presupAper = new List<Presupuesto>();
            presupAprob = new List<Presupuesto>();
            nivelesAprobacion = new List<NivelAprobacion>();
        }

    }
}
