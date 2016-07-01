using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CountryConfig : EntityTypeConfiguration<Country>
    {
        public CountryConfig()
        {
            ToTable("Countries");
            HasKey(x => x.Id);

            HasMany(x => x.Cities).WithRequired(x => x.Country).HasForeignKey(x => x.CountryId);
            HasRequired(x => x.Currency).WithMany(x => x.Countries).HasForeignKey(x => x.CurrencyCode);
            HasMany(x => x.Languages).WithMany(x => x.Countries)
                .Map(x => {
                    x.MapLeftKey("CountryId");
                    x.MapRightKey("LanguageCode");
                    x.ToTable("CountriesLanguages");
                });
        }
    }
}
