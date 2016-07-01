using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.DataBuilder.Models
{
    public class GeoCountryModel
    {
        public string IsoCode { get; set; }
        public string Iso3Code { get; set; }
        public string IsoNumericCode { get; set; }
        public string FipsCode { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public float Area { get; set; }
        public int Population { get; set; }
        public string ContinentCode { get; set; }
        public string TopLevelDomain { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string PhonePrefix { get; set; }
        public string PostalCodeFormat { get; set; }
        public string PostalCodeRegex { get; set; }
        public List<string> Languages { get; set; }
        public int GeoNameId { get; set; }
        public List<string> NeighbourCountryCodes { get; set; }
        public string EquivalentFipsCode { get; set; }
    }
}
