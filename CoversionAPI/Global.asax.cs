

namespace CoversionAPI
{
    using CoversionAPI.Repository.Implementation;
    using CoversionAPI.Repository.Interface;
    using SimpleInjector;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_BeginRequest()
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, PATCH, DELETE, OPTIONS");

                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Pragma, Cache-Control, Authorization ");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            container.Register<IConvertAmount, ConvertAmount>();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyReolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorDependencyReolver(container);
        }
    }
}
