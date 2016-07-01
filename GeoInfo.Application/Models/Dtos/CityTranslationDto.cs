using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Application.Models.Dtos
{
    public class CityTranslationDto
    {
        public LanguageDto Language { get; set; }
        public string Translation { get; set; }
    }
}
