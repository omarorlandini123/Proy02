using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using System.ComponentModel.DataAnnotations;
namespace AppV2.Models
{
    public class ViewModelPresupPorSede
    {
        public List<ViewPresupuestoGeneral> presupuestosPorAnio { get; set; }
        public Usuario usuario { get; set; }

    }


}