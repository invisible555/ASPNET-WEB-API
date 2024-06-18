using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Dto.Authors
{
    public class AuthorsInputDto
    {

        [Required]
        [MaxLength(100)]
        public string Name { set; get; }
        [Required]
        public List<int> BooksId{ get; set; }
        public int? PublishersId { set; get; }

    }
}
