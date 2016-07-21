using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoInfo.Application.EntityMappers;
using GeoInfo.Application.Models.DataBuilder;
using GeoInfo.Infrastructure.Data.Repositories;
using GeoInfo.Infrastructure.Data;

namespace GeoInfo.Application.Services
{
    public class DataBuilderService
    {
        private GeoInfoDbContext _dbContext;

        public DataBuilderService(string dbPath)
        {
            _dbContext = new GeoInfoDbContext(dbPath);
        }

        public void BuildData(List<GeoNameModel> geoNames, List<GeoCountryModel> geoCountries, List<GeoAlternateNameModel> geoAlternateNames, List<GeoLanguageModel> geoLanguages, Dictionary<string, string> timeZonesMapping)
        {
            _dbContext.CreateDataBase();
            BuildLanguageData(geoLanguages);
            BuildCurrencyData(geoCountries);
            BuildCountryData(geoCountries, geoAlternateNames, geoLanguages);
            BuildCityData(geoNames, geoAlternateNames, geoLanguages, timeZonesMapping);
        }

        private void BuildCurrencyData(List<GeoCountryModel> geoCountries)
        {
            var currenciesRepository = new CurrenciesRepository(_dbContext);
            var geoCountriesFiltered = geoCountries.GroupBy(c => c.CurrencyCode).Select(c => c.First()).ToList();

            geoCountriesFiltered.ForEach(async (c) =>
            {
                await currenciesRepository.InsertAsync(CurrencyMapper.Map(c));
            });
        }

        private void BuildCityData(List<GeoNameModel> geoNames, List<GeoAlternateNameModel> geoAlternateNames, List<GeoLanguageModel> geoLanguages, Dictionary<string, string> timeZonesMapping)
        {
            var citiesRepository = new CitiesRepository(_dbContext);
            var countriesRepository = new CountriesRepository(_dbContext);
            geoNames.ForEach(async (n) =>
            {
                var countryId = countriesRepository.FindByCode(n.CountryCode).Id;
                await citiesRepository.InsertAsync(CityMapper.Map(n, geoAlternateNames, geoLanguages, timeZonesMapping, countryId));
            });
        }

        private void BuildLanguageData(List<GeoLanguageModel> geoLanguages)
        {
            var languagesRepository = new LanguagesRepository(_dbContext);
            var geoLanguagesFiltered = geoLanguages.Where(l => !string.IsNullOrEmpty(l.Iso6391)).ToList();
            geoLanguagesFiltered.ForEach(async (l) =>
            {
                await languagesRepository.InsertAsync(LanguageMapper.Map(l));

            });
        }

        private void BuildCountryData(List<GeoCountryModel> geoCountries, List<GeoAlternateNameModel> geoAlternateNames, List<GeoLanguageModel> geoLanguages)
        {
            var countriesRepository = new CountriesRepository(_dbContext);
            geoCountries.ForEach(async (c) =>
            {
                await countriesRepository.InsertAsync(CountryMapper.Map(c, geoAlternateNames, geoLanguages));
            });
        }
    }
}
