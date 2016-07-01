using GeoInfo.Application.Models.DataBuilder;
using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
