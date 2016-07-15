using System.Collections.Generic;

namespace GeoInfo.Application.Models.Dtos
{
    public class CountryDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Area { get; set; }
        public long Population { get; set; }
        public string TopLevelInternetDomain { get; set; }
        public string ContinentCode { get; set; }
        public string PhonePrefix { get; set; }
        public string PostalCodeFormat { get; set; }
        public string PostalCodeRegex { get; set; }
        public CurrencyDto Currency { get; set; }
        public IEnumerable<LanguageDto> Languages { get; set; }
        public IEnumerable<CountryTranslationDto> CountryTranslations { get; set; } 
    }
}
