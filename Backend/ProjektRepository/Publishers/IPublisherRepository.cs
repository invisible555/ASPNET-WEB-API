using Projekt.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Repository.Publishers
{
    public interface IPublisherRepository
    {

        Task<Publisher?> GetPublisherByIdAsync(int id);
        Task<List<Publisher>> GetPublishersByNameAsync(string name);
        Task<List<Publisher?>> GetAllPublishersAsync();
        Task<bool> SavePublisherAsync(Publisher publisher);
        Task<bool> DeletePublisherAsync(int id);
    }
}
