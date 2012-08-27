using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Hans.SinglePageApp.Core.Commons;
using Hans.SinglePageApp.Core.Domains;
using Hans.SinglePageApp.Core.Repositories;
using Hans.SinglePageApp.Core.Utils;
using NHibernate;

namespace Hans.SinglePageApp.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BuildContainer();
        }

        private void BuildContainer()
        {
            var builder = new ContainerBuilder();

            // register ISessionFactory as Singleton 
            builder.Register(x => new Infrastructure().Initialize()).SingleInstance();
            // register ISession as instance per web request
            builder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).InstancePerHttpRequest();
            // register controllers
            builder.RegisterControllers(Assembly.Load(AssemblyType.Web)).PropertiesAutowired();
            // register repositories
            builder.RegisterType<Repository<Product>>().As<IRepository<Product>>();
            builder.RegisterType<Repository<OrderProduct>>().As<IRepository<OrderProduct>>();

            // register services
            //builder.RegisterType<CurrentUserService>().As<ICurrentUserService>();

            //builder.RegisterType<HomeController>().OnActivated(x => x.Instance.DinnerRepository = x.Context.Resolve<IRepository<Dinner>>());
            //builder.RegisterType<HomeController>().OnActivated(x => x.Instance.CurrentUserService = x.Context.Resolve<ICurrentUserService>());

            // override default dependency resolver to use Autofac
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}