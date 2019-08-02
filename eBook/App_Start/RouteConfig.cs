﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eBook
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(name: "Users", 
                //url: "Users/{action}/{id}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Books", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "UsersByPostsAddresses",
            //    url: "Posts/UsersByPostsAddresses",
            //    defaults: new { controller = "Posts", action = "UsersByPostsAddresses" }
            //   );
            
        }
    }
}
