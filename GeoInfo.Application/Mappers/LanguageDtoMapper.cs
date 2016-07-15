using GeoInfo.Application.Models.Dtos;
using GeoInfo.Domain.Entities;

namespace GeoInfo.Application.Mappers
{
    public class LanguageDtoMapper
    {
        public static LanguageDto Map(Language language)
        {
            return new LanguageDto
            {
                Name = language.LanguageName,
                Code = language.LanguageCode
            };
        }
    }
}
