using Microsoft.EntityFrameworkCore;
using Projekt.Model.Entities;
using Projekt.Model;
using ProjektRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Repository.Publishers
{
    public class PublisherRepository : BaseRepository, IPublisherRepository
    {
        public PublisherRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Publisher?> GetPublisherByIdAsync(int id)
        {
            var publisher = await DbContext.Publishers.Include(x => x.Books).Include(x => x.Authors).SingleOrDefaultAsync(x => x.Id == id);
            return publisher;
        }
        public async Task<List<Publisher>> GetPublishersByNameAsync(string name)
        {
            return await DbContext.Publishers.Include(x => x.Books).Include(x => x.Authors).Where(x => x.Name == name).ToListAsync();
        }

        public async Task<List<Publisher?>> GetAllPublishersAsync()
        {
            return await DbContext.Publishers.Include(x => x.Books).Include(x => x.Authors).ToListAsync();
        }

        public async Task<bool> SavePublisherAsync(Publisher publisher)
        {
            if (publisher == null)
            {
                return false;
            }

            DbContext.Entry(publisher).State = publisher.Id == default(int) ? EntityState.Added : EntityState.Modified;

            try
            {
                await DbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletePublisherAsync(int id)
        {
            var publisher = await GetPublisherByIdAsync(id);
            if (publisher == null)
            {
                return true;
            }

            DbContext.Publishers.Remove(publisher);
            try
            {
                await DbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

     
    }
}
