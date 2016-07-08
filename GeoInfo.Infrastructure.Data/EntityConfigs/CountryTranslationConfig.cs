using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CountryTranslationConfig : EntityTypeConfiguration<CountryTranslation>
    {
        public CountryTranslationConfig()
        {
            ToTable("CountryTranslations");
            HasKey(x => new { x.CountryId, x.LanguageCode, x.Translation});

            HasRequired(x => x.Country).WithMany(x => x.CountryTranslations).HasForeignKey(x => x.CountryId);
            HasRequired(x => x.Language).WithMany(x => x.CountryTranslations).HasForeignKey(x => x.LanguageCode);
        }
    }
}
