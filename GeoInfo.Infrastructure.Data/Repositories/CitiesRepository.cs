using GeoInfo.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.Repositories
{
    public class CitiesRepository
    {
        private readonly GeoInfoDbContext _dbContext;

        public CitiesRepository(string dbPath)
        {
            _dbContext = new GeoInfoDbContext(dbPath);
        }

        public CitiesRepository(GeoInfoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertAsync(City city)
        {
            _dbContext.Set<City>().Add(city);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public City FindByIata(string iataCode)
        {
            return _dbContext.Set<City>().FirstOrDefault(c => c.IataCode == iataCode);
        }

        public List<City> FindByNameOrTranslation(string nameOrTranslation)
        {
            var cities = _dbContext.Set<City>().Where(c => c.LocalName == nameOrTranslation).ToList();
            cities.AddRange(_dbContext.Set<City>().Where(c => c.CityTranslations.Any(t => t.Translation == nameOrTranslation)));
            return cities.Distinct().ToList();
        }
    }
}
