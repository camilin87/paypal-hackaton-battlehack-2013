using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FundsForKids.Ninject;
using Ninject;
using Ninject.Syntax;

namespace FundsForKids
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IResolutionRoot _resolutionRoot;

        public NinjectDependencyResolver(IResolutionRoot kernel)
        {
            _resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _resolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolutionRoot.GetAll(serviceType);
        }
    }

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            SetupDependencyInjection();
        }

        public void SetupDependencyInjection()
        {
            IKernel kernel = new StandardKernel(new FundsFKidsNinjectModule());

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}