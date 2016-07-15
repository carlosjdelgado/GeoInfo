using GeoInfo.Domain.Entities;
using GeoInfo.Application.Models.DataBuilder;

namespace GeoInfo.Application.EntityMappers
{
    public class LanguageMapper
    {
        public static Language Map(GeoLanguageModel geoLanguage)
        {
            return new Language
            {
                LanguageCode = geoLanguage.Iso6391,
                LanguageName = geoLanguage.LanguageName
            };
        }
    }
}
