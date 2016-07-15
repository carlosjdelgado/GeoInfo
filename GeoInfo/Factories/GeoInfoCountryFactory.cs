using GeoInfo.Application.Mappers;
using GeoInfo.Infrastructure.Data;
using GeoInfo.Infrastructure.Data.Repositories;

namespace GeoInfo.Factories
{
    public class GeoInfoCountryFactory
    {
        private readonly CountriesRepository _countriesRepository;

        internal GeoInfoCountryFactory(GeoInfoDbContext dbContext)
        {
            _countriesRepository = new CountriesRepository(dbContext);
        }

        public GeoInfoCountry GetByCode(string countryCode)
        {
            return new GeoInfoCountry(CountryDtoMapper.Map(_countriesRepository.FindByCode(countryCode)));
        }

        public GeoInfoCountry GetByName(string name)
        {
            return new GeoInfoCountry(CountryDtoMapper.Map(_countriesRepository.FindByNameOrTranslation(name)));
        }
    }
}
