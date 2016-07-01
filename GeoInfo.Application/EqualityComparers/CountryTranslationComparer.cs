using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Application.EqualityComparers
{
    public class CountryTranslationComparer : IEqualityComparer<CountryTranslation>
    {
        public bool Equals(CountryTranslation x, CountryTranslation y)
        {
            return (x.CountryId == y.CountryId &&
                    x.LanguageCode.ToUpper() == y.LanguageCode.ToUpper());
        }

        public int GetHashCode(CountryTranslation obj)
        {
            return (obj.CountryId + obj.LanguageCode.ToUpper()).GetHashCode();
        }
    }
}
