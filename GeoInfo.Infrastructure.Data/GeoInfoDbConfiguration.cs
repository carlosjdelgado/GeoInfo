using System.Data.Entity;

namespace GeoInfo.Infrastructure.Data
{
    public class GeoInfoDbConfiguration : DbConfiguration
    {
        public GeoInfoDbConfiguration()
        {
            SetProviderServices("System.Data.SqlServerCe.4.0", System.Data.Entity.SqlServerCompact.SqlCeProviderServices.Instance);
        }
    }
}
