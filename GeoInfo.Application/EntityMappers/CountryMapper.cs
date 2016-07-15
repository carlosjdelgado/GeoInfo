using System.Collections.Generic;
using GeoInfo.Application.Models.DataBuilder;
using GeoInfo.Domain.Entities;
using System.Linq;
using GeoInfo.Application.EqualityComparers;
using System;

namespace GeoInfo.Application.EntityMappers
{
    public class CountryMapper
    {
        public static Country Map(GeoCountryModel geoCountry, List<GeoAlternateNameModel> geoAlternateNames, List<GeoLanguageModel> geoLanguages)
        {
            return new Country
            {
                IsoCode = geoCountry.IsoCode,
                Area = geoCountry.Area,
                ContinentCode = geoCountry.ContinentCode,
                LocalName = geoCountry.Name,
                PhonePrefix = geoCountry.PhonePrefix,
                Population = geoCountry.Population,
                PostalCodeFormat = geoCountry.PostalCodeFormat,
                PostalCodeRegex = geoCountry.PostalCodeRegex,
                TopLevelInternetDomain = geoCountry.TopLevelDomain,
                CountryLanguages = BuildCountryLanguages(geoCountry.Languages),
                CountryTranslations = BuildCountryTranslations(geoCountry, geoAlternateNames, geoLanguages),
                CurrencyCode = geoCountry.CurrencyCode                
            };
        }

        private static ICollection<CountryLanguage> BuildCountryLanguages(List<string> languageCodes)
        {
            var countryLanguages = new List<CountryLanguage>();

            languageCodes.Where(l => l.Length == 2).ToList().ForEach(l => countryLanguages.Add(new CountryLanguage
            {
                LanguageCode = l
            }));

            return countryLanguages;
        }

        private static ICollection<CountryTranslation> BuildCountryTranslations(GeoCountryModel geoCountry, List<GeoAlternateNameModel> geoAlternateNames, List<GeoLanguageModel> geoLanguages)
        {
            var countryTranslations = new List<CountryTranslation>();

            geoAlternateNames.Where(a => a.GeoNameId == geoCountry.GeoNameId)
                .Where(a => a.IsoLanguage.Length == 2).ToList()
                .ForEach(a =>
                {
                    countryTranslations.Add(new CountryTranslation
                    {
                        LanguageCode = a.IsoLanguage,
                        Translation = a.AlternateName
                    });
                });

            return countryTranslations.Distinct(new CountryTranslationComparer()).Select(t => t).ToList();
        }

    }
}