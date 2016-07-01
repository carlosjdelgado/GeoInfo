using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.Repositories
{
    public class CurrenciesRepository
    {
        private readonly GeoInfoDbContext _dbContext;

        public CurrenciesRepository(string nameOrConnectionString)
        {
            _dbContext = new GeoInfoDbContext(nameOrConnectionString);
        }

        public CurrenciesRepository()
        {
            _dbContext = new GeoInfoDbContext();
        }

        public CurrenciesRepository(GeoInfoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertAsync(Currency currency)
        {
            _dbContext.Set<Currency>().Add(currency);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public Currency FindByCode(string currencyCode)
        {
            return _dbContext.Currencies.Find(currencyCode);
        }
    }
}
