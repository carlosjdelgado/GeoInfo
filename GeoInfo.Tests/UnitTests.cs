using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using GeoInfo;

namespace GeoInfo.Tests
{
    public class UnitTests
    {
        private readonly GeoInfo _geoInfo;
        public UnitTests()
        {
            _geoInfo = new GeoInfo();
        }

        [Fact]
        public void WhenGeoInfoCityIsInstanciated_DoesNotThrow()
        {
            var city = _geoInfo.Cities.GetByNameAndCountryCode("Jaén", "ES");
        }

        [Fact]
        public void WhenGeoInfoCountryIsInstanciated_DoesNotThrow()
        {
            var country = _geoInfo.Cities.GetByName("España");
        }

        [Fact]
        public void WhenGeoInfoCurrencyIsInstanciated_DoesNotThrow()
        {
            var country = _geoInfo.Currencies.GetByCode("EUR");
        }

        [Fact]
        public void WhenGeoInfoLanguageIsInstanciated_DoesNotThrow()
        {
            var country = _geoInfo.Languages.GetByCode("es");
        }

        [Fact]
        public void WhenGeoInfoCityIsInstanciated_InstanceHaveData()
        {
            var city = _geoInfo.Cities.GetByNameAndCountryCode("Jaén", "ES");
            Assert.NotNull(city);
        }

        [Fact]
        public void WhenGeoInfoCountryIsInstanciated_InstanceHaveData()
        {
            var country = _geoInfo.Countries.GetByName("España");
            Assert.NotNull(country);
        }

        [Fact]
        public void WhenGeoInfoCurrencyIsInstanciated_InstanceHaveData()
        {
            var currency = _geoInfo.Currencies.GetByCode("EUR");
            Assert.NotNull(currency);
        }

        [Fact]
        public void WhenGeoInfoLanguageIsInstanciated_InstanceHaveData()
        {
            var language = _geoInfo.Languages.GetByCode("es");
            Assert.NotNull(language);
        }

        [Fact]
        public void WhenGeoInfoCityLocalTimeIsRetrieved_TimeIsCorrect()
        {
            var city = _geoInfo.Cities.GetByNameAndCountryCode("London", "GB");
            var cityLocalTime = city.LocalTime;
            var utcNow = DateTime.UtcNow;
            var cityUtcTime = TimeZoneInfo.ConvertTimeToUtc(cityLocalTime, TimeZoneInfo.FindSystemTimeZoneById(city.WindowsTimeZone));

            Assert.True((utcNow - cityUtcTime).TotalSeconds <= 1);
        }
    }
}
