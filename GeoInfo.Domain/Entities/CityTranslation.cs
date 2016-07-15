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
