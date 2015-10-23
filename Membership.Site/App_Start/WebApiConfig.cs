using System.Web.Http;
using System.Web.Http.Controllers;
using Newtonsoft.Json.Serialization;

namespace Membership.Site
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Services.Replace(typeof(IHttpActionInvoker), new ControllerActionInvoker());

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
        }
    }
}