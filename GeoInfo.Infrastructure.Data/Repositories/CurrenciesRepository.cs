using GeoInfo.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.Repositories
{
    public class CurrenciesRepository
    {
        private readonly GeoInfoDbContext _dbContext;

        public CurrenciesRepository(string dbPath)
        {
            _dbContext = new GeoInfoDbContext(dbPath);
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
            return _dbContext.Currencies.Where(x => x.CurrencyCode == currencyCode).SingleOrDefault();
        }
    }
}
