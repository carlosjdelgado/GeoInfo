using GeoInfo.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.Repositories
{
    public class CountriesRepository
    {
        private readonly GeoInfoDbContext _dbContext;

        public CountriesRepository(string dbPath)
        {
            _dbContext = new GeoInfoDbContext(dbPath);
        }

        public CountriesRepository(GeoInfoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertAsync(Country country)
        {
            _dbContext.Set<Country>().Add(country);
            country.CountryLanguages.ToList().ForEach(cl => _dbContext.Languages.Attach(cl.Language));
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
