using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public double Area { get; set; }
        public long Population { get; set; }
        public string TopLevelInternetDomain { get; set; }
        public string ContinentCode { get; set; }
        public string PhonePrefix { get; set; }
        public string PostalCodeFormat { get; set; }
        public string PostalCodeRegex { get; set; }
        public string CurrencyCode { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<CountryTranslation> CountryTranslations { get; set; }
    }
}
