using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoInfo.Application.Models.Dtos;
using GeoInfo.Domain.Entities;

namespace GeoInfo.Application.Mappers
{
    public class CurrencyDtoMapper
    {
        public static CurrencyDto Map(Currency currency)
        {
            return new CurrencyDto
            {
                Code = currency.CurrencyCode,
                Name = currency.CurrencyName
            };
        }
    }
}
