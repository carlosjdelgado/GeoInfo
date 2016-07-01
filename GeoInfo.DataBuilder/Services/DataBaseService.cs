using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.DataBuilder.Services
{

    public class DataBaseService
    {
        private readonly SqlCeEngine _sqlCeEngine;

        public DataBaseService(string connectionStringName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            _sqlCeEngine = new SqlCeEngine(connectionString);
        }

        public void Compact()
        {
            _sqlCeEngine.Compact(null);
        }

    }
}
