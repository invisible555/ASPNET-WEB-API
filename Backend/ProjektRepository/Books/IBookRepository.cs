using Projekt.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Repository.Books
{
    public interface IBookRepository
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<List<Book>> GetBooksByTitleAsync(string title);
        Task<List<Book?>> GetAllBooksAsync();
        Task<bool> SaveBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
    
 

    }
}
