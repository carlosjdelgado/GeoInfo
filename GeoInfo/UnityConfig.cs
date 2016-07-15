using GeoInfo.Infrastructure.Data;
using Microsoft.Practices.Unity;
using Microsoft.Data.Entity;

namespace GeoInfo
{
    internal class UnityConfig
    {
        private const string ConnectionString = @"data source=.\Resources\GeoInfo.sdf";
            

        public static IUnityContainer SetDependencyResolverAndReturnContainer()
        {
            var container = GetContainer();
            return container;
        }

        private static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            RegisterDataAccessFeatures(container);
            return container;
        }

        private static void RegisterDataAccessFeatures(UnityContainer container)
        {
            container.RegisterInstance(typeof(GeoInfoDbContext), new GeoInfoDbContext(ConnectionString));
        }
    }
}
