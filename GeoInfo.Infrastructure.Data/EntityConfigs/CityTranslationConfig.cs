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
    public class CityTranslationConfig : GeoInfoEntityTypeConfiguration<CityTranslation>
    {
        private const string CityIdLangCodeAndTranslationIndexName = "I_CityTranslation";
        public CityTranslationConfig()
        {
            ToTable("CityTranslations");
            HasKey(x => new { x.CityId, x.LanguageCode});

            HasRequired(x => x.City).WithMany(x => x.CityTranslations).HasForeignKey(x => x.CityId);
            HasRequired(x => x.Language).WithMany(x => x.CityTranslations).HasForeignKey(x => x.LanguageCode);

            Property(x => x.LanguageCode)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CityIdLangCodeAndTranslationIndexName, 1)
                    {
                        IsUnique = true
                    }));

            Property(x => x.CityId)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CityIdLangCodeAndTranslationIndexName, 2)
                    {
                        IsUnique = true
                    }));

            Property(x => x.Translation)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CityIdLangCodeAndTranslationIndexName, 3)
                    {
                        IsUnique = true
                    }));
        }
    }
}
