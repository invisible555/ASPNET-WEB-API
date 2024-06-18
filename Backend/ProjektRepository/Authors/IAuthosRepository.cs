using Projekt.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Repository.Authors
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAuthorsByNameAsync(string name);
        Task<Author?> GetAuthorByIdAsync(int id);
        Task<List<Author?>> GetAllAuthorsAsync();
        Task<bool> SaveAuthorAsync(Author author);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
