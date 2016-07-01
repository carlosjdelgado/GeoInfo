using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoInfo.Application.Mappers;
using GeoInfo.Infrastructure.Data;
using GeoInfo.Infrastructure.Data.Repositories;
using Microsoft.Practices.ObjectBuilder2;

namespace GeoInfo.Factories
{
    public class GeoInfoCityFactory
    {
        private readonly CitiesRepository _citiesRepository;

        internal GeoInfoCityFactory(GeoInfoDbContext dbContext)
        {
            _citiesRepository = new CitiesRepository(dbContext);
        }

        public GeoInfoCity GetByIata(string iataCode)
        {
            return new GeoInfoCity(CityDtoMapper.Map(_citiesRepository.FindByIata(iataCode)));
        }

        public GeoInfoCity GetByNameAndCountryCode(string name, string countryCode)
        {
            var city = _citiesRepository.FindByNameOrTranslation(name).FirstOrDefault(c => c.Country.IsoCode == countryCode);
            return new GeoInfoCity(CityDtoMapper.Map(city));
        }

        public List<GeoInfoCity> GetByName(string name)
        {
            var result = new List<GeoInfoCity>();
            var cities = _citiesRepository.FindByNameOrTranslation(name);

            cities.ForEach(c => result.Add(new GeoInfoCity(CityDtoMapper.Map(c))));
            return result;
        }
    }
}
