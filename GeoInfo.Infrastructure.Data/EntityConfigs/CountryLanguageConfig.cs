using GeoInfo.Domain.Entities;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CountryLanguageConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CountryLanguage> entityBuilder)
        {
            entityBuilder.ToTable("CountryLanguages");
            entityBuilder.HasKey(x => new { x.CountryId, x.LanguageCode });

            entityBuilder.HasOne(x => x.Country).WithMany(x => x.CountryLanguages).HasForeignKey(x => x.CountryId);
            entityBuilder.HasOne(x => x.Language).WithMany(x => x.CountryLanguages).HasForeignKey(x => x.LanguageCode);
        }
    }
}
