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
    public class CountryTranslationConfig : GeoInfoEntityTypeConfiguration<CountryTranslation>
    {
        private const string CountryIdLangCodeAndTranslationIndexName = "I_CountryTranslation";

        public CountryTranslationConfig()
        {
            ToTable("CountryTranslations");
            HasKey(x => new { x.CountryId, x.LanguageCode, x.Translation});

            HasRequired(x => x.Country).WithMany(x => x.CountryTranslations).HasForeignKey(x => x.CountryId);
            HasRequired(x => x.Language).WithMany(x => x.CountryTranslations).HasForeignKey(x => x.LanguageCode);

            Property(x => x.LanguageCode)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdLangCodeAndTranslationIndexName, 1)
                    {
                        IsUnique = true
                    }));

            Property(x => x.CountryId)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdLangCodeAndTranslationIndexName, 2)
                    {
                        IsUnique = true
                    }));

            Property(x => x.Translation)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute(CountryIdLangCodeAndTranslationIndexName, 3)
                    {
                        IsUnique = true
                    }));
        }
    }
}
