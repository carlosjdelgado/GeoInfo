using System.Collections.Generic;

namespace GeoInfo.Domain.Entities
{
    public class Currency
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
