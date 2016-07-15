using GeoInfo.Application.Models.DataBuilder;
using GeoInfo.Domain.Entities;

namespace GeoInfo.Application.EntityMappers
{
    public class CurrencyMapper
    {
        public static Currency Map(GeoCountryModel country)
        {
            return new Currency
            {
                CurrencyCode = country.CurrencyCode,
                CurrencyName = country.CurrencyName
            };
        }
    }
}
