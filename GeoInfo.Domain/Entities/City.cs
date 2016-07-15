using System;
using System.Collections.Generic;

namespace GeoInfo.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string LocalName { get; set; }
        public string IataCode { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public int? Altitude { get; set; }
        public long? Population { get; set; }
        public string IanaTimeZone { get; set; }
        public string WindowsTimeZone { get; set; }
        public DateTime? LastModification { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<CityTranslation> CityTranslations { get; set; }
        public virtual Country Country { get; set; }
    }
}
