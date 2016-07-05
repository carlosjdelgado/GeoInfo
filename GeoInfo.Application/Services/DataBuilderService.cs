using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoInfo.Application.EntityMappers;
using GeoInfo.Application.Models.DataBuilder;
using GeoInfo.Infrastructure.Data.Repositories;
using GeoInfo.Infrastructure.Data;
using GeoInfo.Domain.Entities;

namespace GeoInfo.Application.Services
{
    public class DataBuilderService
    {
        public DataBuilderService()
        {
        }

        public void BuildData(List<GeoNameModel> geoNames, List<GeoCountryModel> geoCountries, List<GeoAlternateNameModel> geoAlternateNames, List<GeoLanguageModel> geoLanguages, Dictionary<string, string> timeZonesMapping)
        {
            BuildLanguageData(geoLanguages);
            BuildCurrencyData(geoCountries);
            BuildCountryData(geoCountries, geoAlternateNames, geoLanguages);
            BuildCityData(geoNames, geoAlternateNames, geoLanguages, timeZonesMapping);
        }

        private void BuildCurrencyData(List<GeoCountryModel> geoCountries)
        {
            var geoCountriesFiltered = geoCountries.GroupBy(c => c.CurrencyCode).Select(c => c.First()).ToList();

            Parallel.ForEach(geoCountriesFiltered, async (c) =>
            {
                var currenciesRepository = new CurrenciesRepository();
                await currenciesRepository.InsertAsync(CurrencyMapper.Map(c));
            });
        }

        private void BuildCityData(List<GeoNameModel> geoNames, List<GeoAlternateNameModel> geoAlternateNames, List<GeoLanguageModel> geoLanguages, Dictionary<string, string> timeZonesMapping)
        {
            Parallel.ForEach(geoNames, async (n) =>
            {
                var citiesRepository = new CitiesRepository();
                var countriesRepository = new CountriesRepository();
                var countryId =  countriesRepository.FindByCode(n.CountryCode).Id;
                await citiesRepository.InsertAsync(CityMapper.Map(n, geoAlternateNames, geoLanguages, timeZonesMapping, countryId));
            }); 
        }

        private void BuildLanguageData(List<GeoLanguageModel> geoLanguages)
        {
            var geoLanguagesFiltered = geoLanguages.Where(l => !string.IsNullOrEmpty(l.Iso6391)).ToList();
            Parallel.ForEach(geoLanguagesFiltered, async (l) =>
            {
                var languagesRepository = new LanguagesRepository();
                await languagesRepository.InsertAsync(LanguageMapper.Map(l));

            });
        }

        private void BuildCountryData(List<GeoCountryModel> geoCountries, List<GeoAlternateNameModel> geoAlternateNames, List<GeoLanguageModel> geoLanguages)
        {
            Parallel.ForEach(geoCountries, async (c) =>
            {
                var countriesRepository = new CountriesRepository();
                await countriesRepository.InsertAsync(CountryMapper.Map(c, geoAlternateNames, geoLanguages));
            });
        }
    }
}
