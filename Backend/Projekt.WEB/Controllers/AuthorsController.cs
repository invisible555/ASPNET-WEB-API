using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt.Dto.Books;
using Projekt.Model.Entities;
using Projekt.Model;

using Projekt.Repository.Authors;
using Projekt.Dto.Authors;
using Microsoft.EntityFrameworkCore;
using Projekt.Repository.Books;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;
using AutoMapper;

namespace Projekt.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        private readonly IAuthorRepository _authorRepository;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository authorRepository, AppDbContext dbContext, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _dbContext = dbContext;
            _mapper = mapper;

        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);


            if (author == null)
            {
                return NotFound();
            }
            var authorDto = _mapper.Map<AuthorDto>(author);
            return Ok(authorDto);
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var author = await _authorRepository.GetAuthorsByNameAsync(name);
            if (!author.Any())
            {
                return NotFound();
            }
            var authorDto = _mapper.Map<List<AuthorDto>>(author);
            return Ok(authorDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorRepository.GetAllAuthorsAsync();
            if (!authors.Any())
            {
                return NotFound();
            }
            var authorsDto = _mapper.Map<List<AuthorDto>>(authors);
            return Ok(authorsDto);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorsInputDto author)
        {
            if (author == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var books = new List<Book>();

            foreach (var bookId in author.BooksId)
            {
                //var book = await _bookRepository.GetBookByIdAsync(bookId);
                var book = _dbContext.Books.FirstOrDefault(a => a.Id == bookId);
                if (book != null)
                {
                    books.Add(book);
                }
            }
            var publisher = _dbContext.Publishers.FirstOrDefault(a => a.Id == author.PublishersId);

            var newAuthor = new Author()
            {
                Name = author.Name,
                Books = books,
                Publisher = publisher == null ? null : publisher

            };


            var result = await _authorRepository.SaveAuthorAsync(newAuthor);
            if (!result)
            {
                throw new Exception("Error saving book");
            }
            var authorDto = _mapper.Map<AuthorDto>(newAuthor);
            return Ok(authorDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AuthorsInputDto author)
        {

            if (author == null)
            {
                return BadRequest();

            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var existingAuthor = await _authorRepository.GetAuthorByIdAsync(id);

            if (existingAuthor == null)
            {
                return NotFound();
            }

            var books = new List<Book>();
            foreach (var bookId in author.BooksId)
            {

                var book = _dbContext.Books.FirstOrDefault(a => a.Id == bookId);
                if (book != null)
                {
                    books.Add(book);
                }
            }

            var publisher = _dbContext.Publishers.FirstOrDefault(a => a.Id == author.PublishersId);

            existingAuthor.Name = author.Name;
            existingAuthor.Books = books == null ? null : books;
            existingAuthor.Publisher = publisher == null ? null : existingAuthor.Publisher;



            var result = await _authorRepository.SaveAuthorAsync(existingAuthor);
            if (!result)
            {
                throw new Exception("error updating author");
            }
            var authorDto = _mapper.Map<AuthorDto>(existingAuthor);
            return Ok(authorDto);


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var existingAuthor = await _authorRepository.GetAuthorByIdAsync(id);
            if (existingAuthor == null)
                return NotFound();

            var result = await _authorRepository.DeleteAuthorAsync(id);
            if (!result)
            {
                throw new Exception("Error deleting Author");
            }
            return Ok();

        }

    }
}
