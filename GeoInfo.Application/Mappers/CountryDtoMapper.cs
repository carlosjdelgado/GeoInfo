using System.Collections.Generic;
using System.Linq;
using GeoInfo.Application.Models.Dtos;
using GeoInfo.Domain.Entities;

namespace GeoInfo.Application.Mappers
{
    public class CountryDtoMapper
    {
        public static CountryDto Map(Country country)
        {
            return new CountryDto
            {
                Name = country.LocalName,
                Code = country.IsoCode,
                Area = country.Area,
                Population = country.Population,
                TopLevelInternetDomain = country.TopLevelInternetDomain,
                ContinentCode = country.ContinentCode,
                PhonePrefix = country.PhonePrefix,
                PostalCodeFormat = country.PostalCodeFormat,
                PostalCodeRegex = country.PostalCodeRegex,
                Currency = CurrencyDtoMapper.Map(country.Currency),
                CountryTranslations = BuildCountryTranslations(country.CountryTranslations),
                Languages = BuildLanguages(country.CountryLanguages.Select(cl => cl.Language).ToList())
            };
        }

        private static IEnumerable<LanguageDto> BuildLanguages(ICollection<Language> languages)
        {
            var languageList = new List<LanguageDto>();
            languages.ToList().ForEach(l => languageList.Add(LanguageDtoMapper.Map(l)));
            return languageList;
        }

        private static IEnumerable<CountryTranslationDto> BuildCountryTranslations(ICollection<CountryTranslation> countryTranslations)
        {
            var translations = new List<CountryTranslationDto>();
            countryTranslations.ToList().ForEach(l => translations.Add(CountryTranslationDtoMapper.Map(l)));
            return translations;
        }
    }
}
