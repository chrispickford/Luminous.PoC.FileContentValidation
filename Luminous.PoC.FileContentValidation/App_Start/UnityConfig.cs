using Luminous.PoC.FileContentValidation.Providers;
using Luminous.PoC.FileContentValidation.Validators;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Luminous.PoC.FileContentValidation
{
    internal static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IHttpRequestFileProvider, HttpRequestMultipartFileProvider>();
            container.RegisterType<IFileValidator, FileContentValidator>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}