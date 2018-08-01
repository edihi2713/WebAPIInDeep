using BusinessServices;
using DataModel.UnitOfWork;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace WebAPI2
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICargoServices, CargosServices>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}