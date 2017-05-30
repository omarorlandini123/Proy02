using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AppV2.Models
{
    public class Persona
    {
        [Key]
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string ApellidoPa { get; set; }
        public string ApellidoMa { get; set; }
        
    }
}