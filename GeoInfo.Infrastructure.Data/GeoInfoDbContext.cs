using GeoInfo.Domain.Entities;
using GeoInfo.Infrastructure.Data.EntityConfigs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data
{

    [DbConfigurationType(typeof(GeoInfoDbConfiguration))]
    public class GeoInfoDbContext : DbContext {

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityTranslation> CityTranslations { get; set; }
        public DbSet<CountryTranslation> CountryTranslations { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Language> Languages { get; set; }

        public GeoInfoDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public GeoInfoDbContext() : base("Name=GeoInfoDataBase") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CityConfig());
            modelBuilder.Configurations.Add(new CityTranslationConfig());
            modelBuilder.Configurations.Add(new CountryConfig());
            modelBuilder.Configurations.Add(new CountryTranslationConfig());
            modelBuilder.Configurations.Add(new CurrencyConfig());
            modelBuilder.Configurations.Add(new LanguageConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
