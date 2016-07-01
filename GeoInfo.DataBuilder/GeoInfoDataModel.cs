namespace GeoInfo.DataBuilder
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GeoInfoDataModel : DbContext
    {
        public GeoInfoDataModel()
            : base("name=GeoInfoDataBase")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
