using GeoInfo.Application.Models.Dtos;
using GeoInfo.Domain.Entities;

namespace GeoInfo.Application.Mappers
{
    public class CountryTranslationDtoMapper
    {
        public static CountryTranslationDto Map(CountryTranslation countryTranslation)
        {
            return new CountryTranslationDto
            {
                Language = LanguageDtoMapper.Map(countryTranslation.Language),
                Translation = countryTranslation.Translation
            };
        }
    }
}
