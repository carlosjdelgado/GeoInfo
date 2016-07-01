using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoInfo.Application.Models.Dtos;
using Microsoft.Practices.ObjectBuilder2;

namespace GeoInfo
{
    public class GeoInfoCountry
    {
        private readonly CurrencyDto _currency;
        private readonly IEnumerable<LanguageDto> _languages;
        private readonly IEnumerable<CountryTranslationDto> _translations;

        internal GeoInfoCountry(CountryDto country)
        {
            _currency = country.Currency;
            _languages = country.Languages;
            _translations = country.CountryTranslations;

            Name = country.Name;
            Code = country.Code;
            Area = country.Area;
            Population = country.Population;
            InternetDomain = country.TopLevelInternetDomain;
            ContinentCode = country.ContinentCode;
            PhonePrefix = country.PhonePrefix;
            PostalCodeFormat = country.PostalCodeFormat;
            PostalCodeRegex = country.PostalCodeRegex;
        }

        public string Name { get; }
        public string Code { get; }
        public double Area { get; }
        public long Population { get; }
        public string InternetDomain { get; }
        public string ContinentCode { get; }
        public string PhonePrefix { get; }
        public string PostalCodeFormat { get; }
        public string PostalCodeRegex { get; }
        public GeoInfoCurrency Currency => BuildCurrency();
        public List<GeoInfoLanguage> Languages => BuildLanguages();
        public Dictionary<string, string> Translations => BuildTranslations();

        private GeoInfoCurrency BuildCurrency()
        {
            return new GeoInfoCurrency(_currency);
        }

        private List<GeoInfoLanguage> BuildLanguages()
        {
            List<GeoInfoLanguage> languages = new List<GeoInfoLanguage>();
            _languages.ForEach(l => languages.Add(new GeoInfoLanguage(l)));
            return languages;
        }

        private Dictionary<string, string> BuildTranslations()
        {
            var translations = new Dictionary<string, string>();
            _translations.ForEach(t => translations.Add(t.Language.Code, t.Translation));
            return translations;
        }
    }
}
