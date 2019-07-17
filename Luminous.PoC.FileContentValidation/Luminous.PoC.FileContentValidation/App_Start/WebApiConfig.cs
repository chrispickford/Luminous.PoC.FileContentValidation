using System.Web.Http;

namespace Luminous.PoC.FileContentValidation
{
    internal static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Dependency Injection
            
        }
    }
}
