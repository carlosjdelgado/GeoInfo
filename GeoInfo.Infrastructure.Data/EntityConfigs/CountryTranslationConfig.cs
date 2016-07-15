using GeoInfo.Domain.Entities;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CountryTranslationConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CountryTranslation> entityBuilder)
        {
            entityBuilder.ToTable("CountryTranslations");
            entityBuilder.HasKey(x => new { x.CountryId, x.LanguageCode, x.Translation });

            entityBuilder.HasOne(x => x.Country).WithMany(x => x.CountryTranslations).HasForeignKey(x => x.CountryId);
            entityBuilder.HasOne(x => x.Language).WithMany(x => x.CountryTranslations).HasForeignKey(x => x.LanguageCode);
        }
    }
}
