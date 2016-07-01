using System.Collections.Generic;

namespace GeoInfo.Application.Models.DataBuilder
{
    public class GeoCountryModel
    {
        public string IsoCode { get; set; }
        public string Iso3Code { get; set; }
        public string IsoNumericCode { get; set; }
        public string FipsCode { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public double Area { get; set; }
        public long Population { get; set; }
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
