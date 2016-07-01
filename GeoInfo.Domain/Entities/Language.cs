using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Domain.Entities
{
    public class Language
    {
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }

        public virtual ICollection<CityTranslation> CityTranslations { get; set; }
        public virtual ICollection<CountryTranslation> CountryTranslations { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}
