using GeoInfo.Domain.Entities;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CurrencyConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Currency> entityBuilder)
        {
            entityBuilder.ToTable("Currencies");
            entityBuilder.HasKey(x => x.CurrencyCode);

            entityBuilder.HasMany(x => x.Countries).WithOne(x => x.Currency).HasForeignKey(x => x.CurrencyCode);
        }
    }
}
