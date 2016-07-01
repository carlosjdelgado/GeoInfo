using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.Repositories
{
    public class CountriesRepository
    {
        private readonly GeoInfoDbContext _dbContext;

        public CountriesRepository(string nameOrConnectionString)
        {
            _dbContext = new GeoInfoDbContext(nameOrConnectionString);
        }

        public CountriesRepository(GeoInfoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CountriesRepository()
        {
            _dbContext = new GeoInfoDbContext();
        }

        public async Task InsertAsync(Country country)
        {
            _dbContext.Set<Country>().Add(country);
            country.Languages.ToList().ForEach(l => _dbContext.Languages.Attach(l));                
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public Country FindByCode(string countryCode)
        {
            return _dbContext.Set<Country>().FirstOrDefault(c => c.IsoCode == countryCode);
        }

        public Country FindByNameOrTranslation(string nameOrTranslation)
        {
            return
                _dbContext.Set<Country>()
                    .FirstOrDefault(
                        c =>
                            c.LocalName == nameOrTranslation ||
                            c.CountryTranslations.Any(t => t.Translation == nameOrTranslation));
        }
    }
}
