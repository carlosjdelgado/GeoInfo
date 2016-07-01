using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CityConfig : EntityTypeConfiguration<City>
    {
        public CityConfig()
        {
            ToTable("Cities");
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(x => x.CityTranslations).WithRequired(x => x.City).HasForeignKey(x => x.CityId);
        }
    }
}
