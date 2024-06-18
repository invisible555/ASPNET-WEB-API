using Microsoft.EntityFrameworkCore;
using Projekt.Model;
using Projekt.Model.Entities;
using ProjektRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Repository.Books
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Book>> GetBooksByTitleAsync(string title)
        {
            var books = await DbContext.Books.Include(x => x.Author).Include(x => x.Publisher).Where(x => x.Title == title).ToListAsync();
            return books;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var product = await DbContext.Books.Include(x => x.Author).Include(x => x.Publisher).SingleOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<List<Book?>> GetAllBooksAsync()
        {
            var products = await DbContext.Books.Include(x => x.Author).Include(x => x.Publisher).ToListAsync();
            return products;
        }

     

        public async Task<bool> SaveBookAsync(Book book)
        {
            if(book == null)
            {
                return false;
            }
            DbContext.Entry(book).State = book.Id == default(int) ? EntityState.Added : EntityState.Modified;

            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> DeleteBookAsync(int id)
        {
            var product = await GetBookByIdAsync(id);
            if(product == null)
            {
                return true;
            }
            DbContext.Books.Remove(product);
            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
      
        }
    }
}
