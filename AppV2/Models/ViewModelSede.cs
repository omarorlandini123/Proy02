using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AppV2.Models
{
    public class ViewModelSede 
    {

        [Key]
        [Display(Name ="Código")]
        [DataType(DataType.Text)]
        public int codSede { get; set; }


        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        public String desSede { get; set; }


    }
}