using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Projekt.Model.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int? PublisherId { get; set; }
  
        public Publisher? Publisher { get; set; }
       // [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
