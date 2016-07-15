using GeoInfo.Domain.Entities;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class LanguageConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Language> entityBuilder)
        {
            entityBuilder.ToTable("Languages");
            entityBuilder.HasKey(x => x.LanguageCode);

            entityBuilder.HasMany(x => x.CityTranslations).WithOne(x => x.Language).HasForeignKey(x => x.LanguageCode);
            entityBuilder.HasMany(x => x.CountryTranslations).WithOne(x => x.Language).HasForeignKey(x => x.LanguageCode);

            entityBuilder.HasMany(x => x.CountryLanguages).WithOne(x => x.Language).HasForeignKey(x => x.LanguageCode);
        }
    }
}
