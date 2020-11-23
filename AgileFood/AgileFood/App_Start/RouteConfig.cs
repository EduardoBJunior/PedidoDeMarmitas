using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AgileFood
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                "Fornecedor",
                "Alterar/{id}/",
                new { controller = "Fornecedor", action = "Alterar", id = 0 }
            );

            routes.MapRoute(
                "Fornecedor",
                "ConsultarFornecedor",
                new { controller = "Fornecedor", action = "ConsultarFornecedor", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
