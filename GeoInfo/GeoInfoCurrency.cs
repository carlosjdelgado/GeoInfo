using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoInfo.Application.Models.Dtos;

namespace GeoInfo
{
    public class GeoInfoCurrency
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        internal GeoInfoCurrency(CurrencyDto geoInfoCurrencyDto)
        {
            Code = geoInfoCurrencyDto.Code;
            Name = geoInfoCurrencyDto.Name;
        }
    }
}
