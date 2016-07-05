using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CountryConfig : GeoInfoEntityTypeConfiguration<Country>
    {
        private const string CountryIdNameAndCodeIndexName = "I_Country";
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

            Property(x => x.Id)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdNameAndCodeIndexName, 1)
                    {
                        IsUnique = true
                    }));

            Property(x => x.Name)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdNameAndCodeIndexName, 2)
                    {
                        IsUnique = true
                    }));

            Property(x => x.IsoCode)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdNameAndCodeIndexName, 3)
                    {
                        IsUnique = true
                    }));

            Property(x => x.Area)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdNameAndCodeIndexName, 4)
                    {
                        IsUnique = true
                    }));

            Property(x => x.Population)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdNameAndCodeIndexName, 5)
                    {
                        IsUnique = true
                    }));

            Property(x => x.TopLevelInternetDomain)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdNameAndCodeIndexName, 6)
                    {
                        IsUnique = true
                    }));

            Property(x => x.ContinentCode)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdNameAndCodeIndexName, 7)
                    {
                        IsUnique = true
                    }));

            Property(x => x.PhonePrefix)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdNameAndCodeIndexName, 8)
                    {
                        IsUnique = true
                    }));

            Property(x => x.PostalCodeFormat)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdNameAndCodeIndexName, 9)
                    {
                        IsUnique = true
                    }));

            Property(x => x.PostalCodeRegex)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdNameAndCodeIndexName, 10)
                    {
                        IsUnique = true
                    }));

            Property(x => x.CurrencyCode)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdNameAndCodeIndexName, 11)
                    {
                        IsUnique = true
                    }));
        }
    }
}
