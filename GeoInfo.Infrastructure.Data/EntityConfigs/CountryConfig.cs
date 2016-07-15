using GeoInfo.Domain.Entities;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CountryConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Country> entityBuilder)
        {
            entityBuilder.ToTable("Countries");
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.HasMany(x => x.Cities).WithOne(x => x.Country).HasForeignKey(x => x.CountryId);
            entityBuilder.HasOne(x => x.Currency).WithMany(x => x.Countries).HasForeignKey(x => x.CurrencyCode);

            entityBuilder.HasMany(x => x.CountryLanguages).WithOne(x => x.Country).HasForeignKey(x => x.CountryId);
        }
    }
}
