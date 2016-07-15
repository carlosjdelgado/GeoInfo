using GeoInfo.Application.Mappers;
using GeoInfo.Infrastructure.Data;
using GeoInfo.Infrastructure.Data.Repositories;

namespace GeoInfo.Factories
{
    public class GeoInfoCurrencyFactory
    {
        private readonly CurrenciesRepository _currenciesRepository;

        internal GeoInfoCurrencyFactory(GeoInfoDbContext dbContext)
        {
            _currenciesRepository = new CurrenciesRepository(dbContext);
        }

        public GeoInfoCurrency GetByCode(string currencyCode)
        {
            return new GeoInfoCurrency(CurrencyDtoMapper.Map(_currenciesRepository.FindByCode(currencyCode)));
        }
    }
}
