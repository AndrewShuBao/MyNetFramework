using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace MyNetFramework.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        private void SetupResolveRules(ContainerBuilder builder)
        {
            var daoAssembly = Assembly.Load("MyNetFramework.Dao");
            var serviceAssembly = Assembly.Load("MyNetFramework.Service");
            builder.RegisterAssemblyTypes(daoAssembly).SingleInstance();
            builder.RegisterAssemblyTypes(daoAssembly).Where(t => t.Name.EndsWith("Dao")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(serviceAssembly).SingleInstance();
            builder.RegisterAssemblyTypes(serviceAssembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            #region 依赖注入
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.DependencyResolver = (new AutofacWebApiDependencyResolver(container));
            #endregion

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
