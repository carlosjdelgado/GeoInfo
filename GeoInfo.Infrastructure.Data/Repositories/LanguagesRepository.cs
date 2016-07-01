using GeoInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.Repositories
{
    public class LanguagesRepository
    {
        private readonly GeoInfoDbContext _dbContext;

        public LanguagesRepository(string nameOrConnectionString)
        {
            _dbContext = new GeoInfoDbContext(nameOrConnectionString);
        }

        public LanguagesRepository(GeoInfoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public LanguagesRepository()
        {
            _dbContext = new GeoInfoDbContext();
        }

        public async Task InsertAsync(Language language)
        {
            _dbContext.Set<Language>().Add(language);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public Language FindByCode(string languageCode)
        {
            return _dbContext.Set<Language>().Find(languageCode);
        }
    }
}
