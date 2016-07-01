using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoInfo.Application.Models.Dtos;
using GeoInfo.Domain.Entities;

namespace GeoInfo.Application.Mappers
{
    public class CityTranslationDtoMapper
    {
        public static CityTranslationDto Map(CityTranslation cityTranslation)
        {
            return new CityTranslationDto
            {
                Language = LanguageDtoMapper.Map(cityTranslation.Language),
                Translation = cityTranslation.Translation
            };
        }
    }
}
