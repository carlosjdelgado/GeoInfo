using GeoInfo.Factories;
using GeoInfo.Infrastructure.Data;
using Microsoft.Practices.Unity;

namespace GeoInfo
{
    public class GeoInfo
    {
        private readonly GeoInfoDbContext _dbContext;

        private GeoInfoCurrencyFactory _geoInfoCurrencyFactory;
        private GeoInfoCityFactory _geoInfoCityFactory;
        private GeoInfoCountryFactory _geoInfoCountryFactory;
        private GeoInfoLanguageFactory _geoInfoLanguageFactory;

        public GeoInfoCurrencyFactory Currencies => GetGeoInfoCurrencyFactory();
        public GeoInfoCityFactory Cities => GetGeoInfoCityFactory();
        public GeoInfoCountryFactory Countries => GetGeoInfoCountryFactory();
        public GeoInfoLanguageFactory Languages => GetGeoInfoLanguageFactory();

        public GeoInfo()
        {
            var container = UnityConfig.SetDependencyResolverAndReturnContainer();
            _dbContext = container.Resolve<GeoInfoDbContext>();
        }

        private GeoInfoCurrencyFactory GetGeoInfoCurrencyFactory()
        {
            return _geoInfoCurrencyFactory ?? (_geoInfoCurrencyFactory = new GeoInfoCurrencyFactory(_dbContext));
        }
        private GeoInfoCityFactory GetGeoInfoCityFactory()
        {
            return _geoInfoCityFactory ?? (_geoInfoCityFactory = new GeoInfoCityFactory(_dbContext));
        }
        private GeoInfoCountryFactory GetGeoInfoCountryFactory()
        {
            return _geoInfoCountryFactory ?? (_geoInfoCountryFactory = new GeoInfoCountryFactory(_dbContext));
        }
        private GeoInfoLanguageFactory GetGeoInfoLanguageFactory()
        {
            return _geoInfoLanguageFactory ?? (_geoInfoLanguageFactory = new GeoInfoLanguageFactory(_dbContext));
        }
    }
}

