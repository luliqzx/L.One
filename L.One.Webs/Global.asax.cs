using L.One.Domain.Common;
using L.One.Domain.Repository;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using L.Core.Utilities;

namespace L.One.Webs
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            this.SetUp();

        }

        private void SetUp()
        {
            // Simple Injector set up
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            // Register your stuff here  
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Singleton);
            container.Register<IActorRepository, ActorRepository>(Lifestyle.Singleton);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            try
            {
                container.Verify(VerificationOption.VerifyAndDiagnose);
                DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            }
            catch (Exception ex)
            {
                string err = ex.GetFullMessage();
            }
        }
    }
}
