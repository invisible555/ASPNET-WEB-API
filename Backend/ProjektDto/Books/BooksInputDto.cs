using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Dto.Books
{
    public class BooksInputDto
    {
    
        [Required]
        [MaxLength(100)]
        public string Title { set; get; }
        [Required]
        public int AuthorId { set; get; }
        public int? PublisherId { set; get; } 
        public DateTime PublishedDate { set; get; }


    }
}
