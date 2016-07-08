using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoInfo.Application.Models.Dtos;
using GeoInfo.Domain.Entities;

namespace GeoInfo.Application.Mappers
{
    public class CityDtoMapper
    {
        public static CityDto Map(City city)
        {
            if (city == null) return null;

            return new CityDto
            {
                Name = city.LocalName,
                IataCode = city.IataCode,
                Latitude = city.Latitude,
                Longitude = city.Longitude,
                Altitude = city.Altitude,
                Population = city.Population,
                IanaTimeZone = city.IanaTimeZone,
                WindowsTimeZone = city.WindowsTimeZone,
                Country = CountryDtoMapper.Map(city.Country),
                CityTranslations = BuildCityTranslations(city.CityTranslations)
            };
        }

        private static IEnumerable<CityTranslationDto> BuildCityTranslations(ICollection<CityTranslation> cityTranslations)
        {
            var translations = new List<CityTranslationDto>();
            cityTranslations.ToList().ForEach(ct => translations.Add(CityTranslationDtoMapper.Map(ct)));
            return translations;
        }
    }
}
