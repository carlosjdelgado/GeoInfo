using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoInfo.Application.EntityMappers;
using GeoInfo.Application.Models.DataBuilder;
using GeoInfo.Infrastructure.Data.Repositories;
using GeoInfo.Infrastructure.Data;
using System.Collections.Concurrent;
using GeoInfo.Domain.Entities;

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
            var geoCountriesFiltered = geoCountries.GroupBy(c => c.CurrencyCode).Select(c => c.First()).ToList();

            geoCountriesFiltered.ForEach(c =>
            {
                _dbContext.Currencies.Add(CurrencyMapper.Map(c));
            });

            _dbContext.SaveChanges();
        }

        private void BuildCityData(List<GeoNameModel> geoNames, List<GeoAlternateNameModel> geoAlternateNames, List<GeoLanguageModel> geoLanguages, Dictionary<string, string> timeZonesMapping)
        {
            var countriesRepository = new CountriesRepository(_dbContext);
            var countriesDictionary = new Dictionary<string, int>();
            _dbContext.Countries.ToList().ForEach(c => countriesDictionary.Add(c.IsoCode, c.Id));
                
            var citiesToAdd = new ConcurrentBag<City>();

            geoNames.ForEach(n =>
            {
                _dbContext.Add(CityMapper.Map(n, geoAlternateNames, geoLanguages, timeZonesMapping, countriesDictionary[n.CountryCode]));
            });

            _dbContext.SaveChanges();
        }

        private void BuildLanguageData(List<GeoLanguageModel> geoLanguages)
        {
            var geoLanguagesFiltered = geoLanguages.Where(l => !string.IsNullOrEmpty(l.Iso6391)).ToList();
            geoLanguagesFiltered.ForEach(l =>
            {
                _dbContext.Languages.Add(LanguageMapper.Map(l));

            });

            _dbContext.SaveChanges();
        }

        private void BuildCountryData(List<GeoCountryModel> geoCountries, List<GeoAlternateNameModel> geoAlternateNames, List<GeoLanguageModel> geoLanguages)
        {
            geoCountries.ForEach(c =>
            {
                _dbContext.Countries.Add(CountryMapper.Map(c, geoAlternateNames, geoLanguages));
            });

            _dbContext.SaveChanges();
        }
    }
}
