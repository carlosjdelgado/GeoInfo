using GeoInfo.Domain.Entities;
using GeoInfo.Infrastructure.Data.EntityConfigs;
using Microsoft.Data.Entity;

namespace GeoInfo.Infrastructure.Data
{
    public class GeoInfoDbContext : DbContext {

        private string _dbPath;

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityTranslation> CityTranslations { get; set; }
        public DbSet<CountryTranslation> CountryTranslations { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Language> Languages { get; set; }

        public GeoInfoDbContext(string path) : base()
        {
            _dbPath = path;
        }

        public bool CreateDataBase()
        {
            return Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(string.Format("Data Source={0}", _dbPath));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CityConfig.SetEntityBuilder(modelBuilder.Entity<City>());
            CityTranslationConfig.SetEntityBuilder(modelBuilder.Entity<CityTranslation>());
            CountryConfig.SetEntityBuilder(modelBuilder.Entity<Country>());
            CountryTranslationConfig.SetEntityBuilder(modelBuilder.Entity<CountryTranslation>());
            CurrencyConfig.SetEntityBuilder(modelBuilder.Entity<Currency>());
            LanguageConfig.SetEntityBuilder(modelBuilder.Entity<Language>());
            CountryLanguageConfig.SetEntityBuilder(modelBuilder.Entity<CountryLanguage>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
