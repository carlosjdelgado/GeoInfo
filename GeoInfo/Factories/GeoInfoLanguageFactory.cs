using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoInfo.Application.Mappers;
using GeoInfo.Infrastructure.Data;
using GeoInfo.Infrastructure.Data.Repositories;

namespace GeoInfo.Factories
{
    public class GeoInfoLanguageFactory
    {
        private readonly LanguagesRepository _languagesRepository;

        internal GeoInfoLanguageFactory(GeoInfoDbContext dbContext)
        {
            _languagesRepository = new LanguagesRepository(dbContext);
        }

        public GeoInfoLanguage GetByCode(string languageCode)
        {
            return new GeoInfoLanguage(LanguageDtoMapper.Map(_languagesRepository.FindByCode(languageCode)));
        }
    }
}
