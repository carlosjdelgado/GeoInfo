using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Application.Models.Dtos
{
    public class CityDto
    {
        public string Name { get; set; }
        public string IataCode { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public int? Altitude { get; set; }
        public long? Population { get; set; }
        public string IanaTimeZone { get; set; }
        public string WindowsTimeZone { get; set; }
        public CountryDto Country { get; set; }
        public IEnumerable<CityTranslationDto> CityTranslations { get; set; }
    }
}
