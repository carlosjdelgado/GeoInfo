using GeoInfo.Domain.Entities;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CityTranslationConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CityTranslation> entityBuilder)
        {
            entityBuilder.ToTable("CityTranslations");
            entityBuilder.HasKey(x => new { x.CityId, x.LanguageCode });

            entityBuilder.HasOne(x => x.City).WithMany(x => x.CityTranslations).HasForeignKey(x => x.CityId);
            entityBuilder.HasOne(x => x.Language).WithMany(x => x.CityTranslations).HasForeignKey(x => x.LanguageCode);
        }
    }
}
