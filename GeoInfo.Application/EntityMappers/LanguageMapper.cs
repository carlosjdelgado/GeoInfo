using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
