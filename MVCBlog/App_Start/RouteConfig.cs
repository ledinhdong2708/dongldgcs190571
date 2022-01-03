using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            /*routes.MapRoute(
                "Create Course With Instructor",
                "Courses/Create/{instructor_id}/{instructor_name}",
                new {
                    controller = "Courses",
                    action = "Create",
                    instructor_id = UrlParameter.Optional,
                    instructor_name = UrlParameter.Optional
                });
            */
        }
    }
}
