using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AppV2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Presupuesto/Detalle",
                url: "{controller}/{action}/{id}/{idTipo}",
                defaults: new { controller = "Presupuesto", action = "Detalle", id = UrlParameter.Optional,idTipo=UrlParameter.Optional }
            );


        }
    }
}
