using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.EntityConfigs
{
    public class CityConfig : GeoInfoEntityTypeConfiguration<City>
    {
        private const string CityIndexName = "I_City";
        public CityConfig()
        {
            ToTable("Cities");
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(x => x.CityTranslations).WithRequired(x => x.City).HasForeignKey(x => x.CityId);

            Property(x => x.Id).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(CityIndexName, 1)
                {
                    IsUnique = true
                }));

            Property(x => x.Name).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(CityIndexName, 2)
                {
                    IsUnique = true
                }));

            Property(x => x.IataCode).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(CityIndexName, 3)
                {
                    IsUnique = true
                }));

            Property(x => x.Latitude).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(CityIndexName, 4)
                {
                    IsUnique = true
                }));

            Property(x => x.Longitude).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(CityIndexName, 5)
                {
                    IsUnique = true
                }));

            Property(x => x.Altitude).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(CityIndexName, 6)
                {
                    IsUnique = true
                }));

            Property(x => x.Population).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(CityIndexName, 7)
                {
                    IsUnique = true
                }));

            Property(x => x.IanaTimeZone).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(CityIndexName, 8)
                {
                    IsUnique = true
                }));

            Property(x => x.WindowsTimeZone).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(CityIndexName, 9)
                {
                    IsUnique = true
                }));

            Property(x => x.LastModification).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(CityIndexName, 10)
                {
                    IsUnique = true
                }));

            Property(x => x.CountryId).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(CityIndexName, 11)
                {
                    IsUnique = true
                }));
        }
    }
}
