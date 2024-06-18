using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projekt.Model.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
      //  [JsonIgnore]
        public ICollection<Author> Authors { get; set; }
       // [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
