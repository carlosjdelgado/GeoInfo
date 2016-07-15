using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Domain.Entities
{
    public class CountryLanguage
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string LanguageCode { get; set; }
        public virtual Language Language { get; set; }
    }
}
