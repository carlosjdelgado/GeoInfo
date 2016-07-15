using GeoInfo.Domain.Entities;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<City> entityBuilder)
        {
            entityBuilder.ToTable("Cities");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            entityBuilder.HasMany(x => x.CityTranslations).WithOne(x => x.City).HasForeignKey(x => x.CityId);
        }
    }
}
