using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AppV2.Models
{
    public class ViewModelCuentaUsuario
    {

        [Key]
        public int idUsuario { get; set; }
        [Display(Name ="Usuario")]
        [DataType(DataType.Text)]
        [Required]
        public string usuario { get; set; }
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }
        public Persona Persona { get; set; }
        public ViewModelCuentaUsuario() {
            Persona = new Persona();
        }

    }
}