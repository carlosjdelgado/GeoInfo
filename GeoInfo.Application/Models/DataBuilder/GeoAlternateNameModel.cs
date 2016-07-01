namespace GeoInfo.Application.Models.DataBuilder
{
    public class GeoAlternateNameModel
    {
        public int AlternateNameId { get; set; }
        public int GeoNameId { get; set; }
        public string IsoLanguage { get; set; }
        public string AlternateName { get; set; }
        public bool IsPreferredName { get; set; }
        public bool IsShortName { get; set; }
        public bool IsColloquial { get; set; }
        public bool IsHistoric { get; set; }
    }
}
