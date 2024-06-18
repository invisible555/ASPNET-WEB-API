using Projekt.Model;

namespace ProjektRepository
{
    public abstract class BaseRepository
    {
        protected AppDbContext DbContext;

        public BaseRepository(AppDbContext dbContext)
        {
             DbContext = dbContext;
        }
    }
}
