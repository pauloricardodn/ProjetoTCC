using SimpleInjector.Integration.WebApi;
using System.Web.Http.Dependencies;
using Web_Api;

namespace WebApi
{
    public class WebApiApplication : WebApiConfig
    {
        private static readonly IDependencyResolver _depResolver = new SimpleInjectorWebApiDependencyResolver(SimpleInjectorContainer.RegisterServices());
        public WebApiApplication() : base(_depResolver)
        {

        }
    }
}
