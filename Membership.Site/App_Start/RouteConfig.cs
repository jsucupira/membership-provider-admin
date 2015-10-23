using System.Web.Mvc;
using System.Web.Routing;

namespace Membership.Site
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapMvcAttributeRoutes();

            routes.MapRoute("UsersRoute", "users/{relative}/{*id}", 
                new {controller = "Users", action = "Index", id = UrlParameter.Optional});

            routes.MapRoute("RolesRoute", "roles/{relative}/{*id}", 
                new {controller = "Roles", action = "Index", id = UrlParameter.Optional});

            routes.MapRoute("Direct", "{controller}/{action}/{id}", 
                new {controller = "Home", action = "Index", id = UrlParameter.Optional});
        }
    }
}