using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class GeoInfoEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
    }
}
