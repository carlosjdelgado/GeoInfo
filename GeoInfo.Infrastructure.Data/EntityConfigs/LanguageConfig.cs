using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class LanguageConfig : EntityTypeConfiguration<Language>
    {
        public LanguageConfig()
        {
            ToTable("Languages");
            HasKey(x => x.LanguageCode);

            HasMany(x => x.CityTranslations).WithRequired(x => x.Language).HasForeignKey(x => x.LanguageCode);
            HasMany(x => x.CountryTranslations).WithRequired(x => x.Language).HasForeignKey(x => x.LanguageCode);

            HasMany(x => x.Countries).WithMany(x => x.Languages)
                .Map(x => {
                    x.MapLeftKey("CountryId");
                    x.MapRightKey("LanguageCode");
                    x.ToTable("CountriesLanguages");
                });
        }
    }
}
