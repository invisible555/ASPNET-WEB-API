using Microsoft.EntityFrameworkCore;
using Projekt.Dto.Books;
using Projekt.Model;
using Projekt.Model.Entities;
using Projekt.Repository.Books;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projekt.Dto.Publishers
{
    public class PublishersInputDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public List<int>? AuthorsId { get; set; }
        [Required]
        public List<int>? BooksId { get; set; }
    }
}
