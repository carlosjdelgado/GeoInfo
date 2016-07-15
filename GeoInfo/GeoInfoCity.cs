using System;
using System.Collections.Generic;
using GeoInfo.Application.Models.Dtos;
using Microsoft.Practices.ObjectBuilder2;

namespace GeoInfo
{
    public class GeoInfoCity
    {
        private readonly CountryDto _country;
        private readonly IEnumerable<CityTranslationDto> _translations;

        internal GeoInfoCity(CityDto city)
        {
            _country = city.Country;
            _translations = city.CityTranslations;

            Name = city.Name;
            IataCode = city.IataCode;
            Latitude = city.Latitude;
            Longitude = city.Longitude;
            Altitude = city.Altitude;
            Population = city.Population;
            IanaTimeZone = city.IanaTimeZone;
            WindowsTimeZone = city.WindowsTimeZone;
        }

        public string Name { get; }
        public string IataCode { get; }
        public float? Latitude { get; }
        public float? Longitude { get; }
        public int? Altitude { get; }
        public long? Population { get; }
        public string IanaTimeZone { get; }
        public string WindowsTimeZone { get; }
        public DateTime LocalTime => GetLocalDateTime();
        public GeoInfoCountry Country => BuildCountry();
        public Dictionary<string, string> Translations => BuildTranslations();

        private GeoInfoCountry BuildCountry()
        {
            return new GeoInfoCountry(_country);
        }

        private DateTime GetLocalDateTime()
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, WindowsTimeZone);
        }

        private Dictionary<string, string> BuildTranslations()
        {
            var translations = new Dictionary<string, string>();
            _translations.ForEach(t => translations.Add(t.Language.Code, t.Translation));
            return translations;
        }
    }
}
