using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoInfo.Application.Models.Dtos;

namespace GeoInfo
{
    public class GeoInfoLanguage
    {
        internal GeoInfoLanguage(LanguageDto language)
        {
            Code = language.Code;
            Name = language.Name;
        }

        public string Code { get; }
        public string Name { get; }
    }
}
