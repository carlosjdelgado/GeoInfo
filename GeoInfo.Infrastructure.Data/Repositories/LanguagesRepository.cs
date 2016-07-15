using GeoInfo.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace GeoInfo.Infrastructure.Data.Repositories
{
    public class LanguagesRepository
    {
        private readonly GeoInfoDbContext _dbContext;

        public LanguagesRepository(string dbPath)
        {
            _dbContext = new GeoInfoDbContext(dbPath);
        }

        public LanguagesRepository(GeoInfoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertAsync(Language language)
        {
            _dbContext.Set<Language>().Add(language);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public Language FindByCode(string languageCode)
        {
            return _dbContext.Languages.Where(x => x.LanguageCode == languageCode).FirstOrDefault();
        }
    }
}
