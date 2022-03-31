using Autofac;
using Autofac.Integration.Mvc;
using Senior.Revenda.IoC;
using Senior.Revenda.Mvc.Controllers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Senior.Revenda.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterFilterProvider();

            builder.RegisterType<MarcaController>().InstancePerRequest();
            builder.RegisterType<VeiculoController>().InstancePerRequest();
            builder.RegisterType<ProprietarioController>().InstancePerRequest();

            DI.RegisterTypes(builder);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(DI.Container));

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
