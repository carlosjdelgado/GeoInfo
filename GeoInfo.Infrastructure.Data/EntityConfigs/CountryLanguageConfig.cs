using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CountryLanguageConfig : EntityTypeConfiguration<CountryLanguage>
    {
        public CountryLanguageConfig()
        {
            ToTable("CountryLanguages");
            HasKey(x => new { x.CountryId, x.LanguageCode });

            HasRequired(x => x.Country).WithMany(x => x.Languages).HasForeignKey(x => x.CountryId);
            HasRequired(x => x.Language).WithMany(x => x.CountryLanguages).HasForeignKey(x => x.LanguageCode);
        }
    }
}
