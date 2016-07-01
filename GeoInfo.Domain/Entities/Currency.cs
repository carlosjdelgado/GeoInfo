using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Domain.Entities
{
    public class Currency
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
