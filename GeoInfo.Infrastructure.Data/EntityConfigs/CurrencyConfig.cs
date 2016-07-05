using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CurrencyConfig : GeoInfoEntityTypeConfiguration<Currency>
    {
        public CurrencyConfig()
        {
            ToTable("Currencies");
            HasKey(x => x.CurrencyCode);

            HasMany(x => x.Countries).WithRequired(x => x.Currency).HasForeignKey(x => x.CurrencyCode);
        }
    }
}
