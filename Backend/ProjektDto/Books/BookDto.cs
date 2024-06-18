using Projekt.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Dto.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public Publisher? Publisher { get; set; }
        public Author Author { get; set; }
        public bool IsBorrowed { get; set; }
    }
}
