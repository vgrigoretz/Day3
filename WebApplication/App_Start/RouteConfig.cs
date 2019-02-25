using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            // http://mycompany.com/trucks.php
            // http://mycompany.com/
            // http://mycompany.com/truck/detail/5/6?p=1&p2=2
            // http://mycompany.com/home/index
            // http://mycompany.com/home/abracadabra

        }
    }
}
