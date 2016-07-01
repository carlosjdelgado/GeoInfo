using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Application.EqualityComparers
{
    public class CityTranslationComparer : IEqualityComparer<CityTranslation>
    {
        public bool Equals(CityTranslation x, CityTranslation y)
        {
            return (x.CityId == y.CityId && x.LanguageCode.ToUpper() == y.LanguageCode.ToUpper());
        }

        public int GetHashCode(CityTranslation obj)
        {
            return (obj.CityId + obj.LanguageCode.ToUpper()).GetHashCode();
        }
    }
}
