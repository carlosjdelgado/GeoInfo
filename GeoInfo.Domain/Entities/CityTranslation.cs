using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Domain.Entities
{
    public class CityTranslation
    {
        public string Translation { get; set; }
        public int CityId { get; set; }
        public string LanguageCode { get; set; }

        public virtual City City { get; set; }
        public virtual Language Language { get; set; }
    }
}
