using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.Repositories
{
    public class CitiesRepository
    {
        private readonly GeoInfoDbContext _dbContext;

        public CitiesRepository(GeoInfoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CitiesRepository(string nameOrConnectionString)
        {
            _dbContext = new GeoInfoDbContext(nameOrConnectionString);
        }

        public CitiesRepository()
        {
            _dbContext = new GeoInfoDbContext();
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
