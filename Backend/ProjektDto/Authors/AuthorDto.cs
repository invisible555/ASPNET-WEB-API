using Projekt.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projekt.Dto.Authors
{
    public class AuthorDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public int? PublisherId { get; set; }

        public Publisher? Publisher { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
