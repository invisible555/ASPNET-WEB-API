using Microsoft.EntityFrameworkCore;
using Projekt.Model.Entities;
using Projekt.Model;
using ProjektRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Repository.Authors
{
    
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        
        public AuthorRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Author>> GetAuthorsByNameAsync(string name)
        {
            var authors = await DbContext.Authors.Include(x=> x.Publisher).Include(x => x.Books).Where(x => x.Name == name).ToListAsync();
            return authors;
        }

        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            var author = await DbContext.Authors.Include(x => x.Publisher).Include(x => x.Books).SingleOrDefaultAsync(x => x.Id == id);
            return author;
        }
        public async Task<List<Author?>> GetAllAuthorsAsync()
        {
            return await DbContext.Authors.Include(x => x.Publisher).Include(x => x.Books).ToListAsync();
        }

        public async Task<bool> SaveAuthorAsync(Author author)
        {
            if (author == null)
            {
                return false;
            }

            DbContext.Entry(author).State = author.Id == default(int) ? EntityState.Added : EntityState.Modified;

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

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await GetAuthorByIdAsync(id);
            if (author == null)
            {
                return true; 
            }

            DbContext.Authors.Remove(author);
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
