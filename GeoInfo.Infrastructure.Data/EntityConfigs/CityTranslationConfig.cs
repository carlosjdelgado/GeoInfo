using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CityTranslationConfig : EntityTypeConfiguration<CityTranslation>
    {
        public CityTranslationConfig()
        {
            ToTable("CityTranslations");
            HasKey(x => new { x.CityId, x.LanguageCode});

            HasRequired(x => x.City).WithMany(x => x.CityTranslations).HasForeignKey(x => x.CityId);
            HasRequired(x => x.Language).WithMany(x => x.CityTranslations).HasForeignKey(x => x.LanguageCode);
        }
    }
}
