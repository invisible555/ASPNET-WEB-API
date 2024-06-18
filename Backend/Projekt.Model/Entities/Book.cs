using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projekt.Model.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }

        public int? PublisherId { get; set; }
  
        public Publisher? Publisher { get; set; }

        public int AuthorId { get; set; }
     
        public Author Author { get; set; }


        public int? UserId { get; set; } // user which borrowed book

        public bool IsBorrowed => UserId.HasValue;
    }
}

