using System;
using System.Collections.Generic;

namespace GeoInfo.Application.Models.DataBuilder
{
    public class GeoNameModel
    {
        public int GeoNameId { get; set; }
        public string Name { get; set; }
        public string AsciiName { get; set; }
        public List<string> AlternateNames { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public char? FeatureClass { get; set; }
        public string FeatureCode { get; set; }
        public string CountryCode { get; set; }
        public List<string> AlternateCountryCodes { get; set; }
        public string Admin1Code { get; set; }
        public string Admin2Code { get; set; }
        public string Admin3Code { get; set; }
        public string Admin4Code { get; set; }
        public long? Population { get; set; }
        public int? Elevation { get; set; }
        public int? DigitalElevationModel { get; set; }
        public string TimeZone { get; set; }
        public DateTime? LastModification { get; set; }
    }
}
