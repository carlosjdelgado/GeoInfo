using System.Collections.Generic;

namespace GeoInfo.Domain.Entities
{
    public class Language
    {
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }

        public virtual ICollection<CityTranslation> CityTranslations { get; set; }
        public virtual ICollection<CountryTranslation> CountryTranslations { get; set; }
        public virtual ICollection<CountryLanguage> CountryLanguages { get; set; }
    }
}
