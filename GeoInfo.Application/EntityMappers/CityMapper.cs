using System.Collections.Generic;
using System.Linq;
using GeoInfo.Application.Models.DataBuilder;
using GeoInfo.Domain.Entities;
using GeoInfo.Application.EqualityComparers;

namespace GeoInfo.Application.EntityMappers
{
    public class CityMapper
    {
        public static City Map(GeoNameModel geoName, 
            List<GeoAlternateNameModel> geoAlternateNames, List<GeoLanguageModel> geoLanguages, Dictionary<string, string> timeZonesMapping, int countryId)
        {
            return new City
            {
                LocalName = geoName.Name,
                IataCode = BuildIataCode(geoName, geoAlternateNames),
                Altitude = geoName.Elevation ?? geoName.DigitalElevationModel,
                LastModification = geoName.LastModification,
                Latitude = geoName.Latitude,
                Longitude = geoName.Longitude,
                IanaTimeZone = geoName.TimeZone,
                Population = geoName.Population,
                WindowsTimeZone = timeZonesMapping[geoName.TimeZone],
                CountryId = countryId,
                CityTranslations = BuildCityTranslations(geoName, geoAlternateNames, geoLanguages)                
            };
        }

        private static ICollection<CityTranslation> BuildCityTranslations(GeoNameModel geoName, List<GeoAlternateNameModel> geoAlternateNames, List<GeoLanguageModel> geoLanguages)
        {
            var cityTranslations = new List<CityTranslation>();

            geoAlternateNames.Where(a => a.GeoNameId == geoName.GeoNameId)
                .Where(a => a.IsoLanguage.Length == 2).ToList()
                .ForEach(a =>
                {
                    cityTranslations.Add(new CityTranslation
                    {                                                
                        LanguageCode = a.IsoLanguage,
                        Translation = a.AlternateName
                    });
                });

            return cityTranslations.Distinct(new CityTranslationComparer()).Select(t => t).ToList();
        }

        private static string BuildIataCode(GeoNameModel geoName, IEnumerable<GeoAlternateNameModel> geoAlternateNames)
        {
            return geoAlternateNames.FirstOrDefault(a => a.IsoLanguage == "iata" && a.GeoNameId == geoName.GeoNameId)?.AlternateName;
        }
    }
}
