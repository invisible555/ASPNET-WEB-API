using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Dto.Books;
using Projekt.Model;
using Projekt.Model.Entities;
using Projekt.Repository.Books;
using System.ComponentModel;

namespace Projekt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository,AppDbContext dbContext,IMapper mapper)
        {
            _bookRepository = bookRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }
        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var book = await _bookRepository.GetBooksByTitleAsync(title);
            if (!book.Any())
            {
                return NotFound();
            }
            var bookDto = _mapper.Map<List<BookDto>>(book);
            return Ok(bookDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            if(!books.Any())
            {
                return NotFound();
            }
            var booksDto = _mapper.Map<List<BookDto>>(books);
            return Ok(booksDto);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BooksInputDto book)
        {
            if (book == null)
            {
                return BadRequest();

            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var author = _dbContext.Authors.FirstOrDefault(a => a.Id == book.AuthorId);
            var publisher = _dbContext.Publishers.FirstOrDefault(a => a.Id == book.PublisherId);

            if (author == null || (publisher == null && book.PublisherId != null))
            {
                return NotFound();
            }

            var newBook = new Book()
            {
                Title = book.Title,
                AuthorId = book.AuthorId,
                Author = author,
                PublisherId = publisher != null ? book.PublisherId : null,
                Publisher = publisher != null ? publisher : null,
            };

            var result = await _bookRepository.SaveBookAsync(newBook);
            if (!result)
            {
                throw new Exception("Error saving book");
            }
            var bookDto =  _mapper.Map<BookDto>(newBook);
            return Ok(bookDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]BooksInputDto book)
        {
            if (book == null)
            {
                return BadRequest();

            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var existingBook = await _bookRepository.GetBookByIdAsync(id);

            if(existingBook == null)
            {
                return NotFound();
            }
            var author = _dbContext.Authors.FirstOrDefault(a => a.Id == book.AuthorId);
            var publisher = _dbContext.Publishers.FirstOrDefault(a => a.Id == book.PublisherId);
            existingBook.Title = book.Title;
            existingBook.AuthorId = book.AuthorId;
            existingBook.PublisherId = book.PublisherId;
            if (author != null)
            {
                existingBook.Author = author;
            }
            if (publisher != null)
            {
                existingBook.Publisher = publisher;
            }

            var result = await _bookRepository.SaveBookAsync(existingBook);
            if(!result)
            {
                throw new Exception("error updating book");
            }
            var bookDto = _mapper.Map<BookDto>(existingBook);
            return Ok(bookDto);
            
        }
        [HttpPut("borrow/{bookId}")]
        public async Task<IActionResult> PutBorrowBook(int bookId,int? userId)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(bookId);
            if(existingBook == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(existingBook.UserId == null)
                existingBook.UserId = userId;
            else if(userId == null)
            {
                existingBook.UserId = null;
            }
            else
                throw new Exception("This book is borrowed");

            var result = await _bookRepository.SaveBookAsync(existingBook);
            if(!result)
            {
                throw new Exception("error updating book");
            }
            var bookDto = _mapper.Map<BookDto>(existingBook);
            return Ok(bookDto);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(id);
            if (existingBook == null)
                return NotFound();

            var result = await _bookRepository.DeleteBookAsync(id);
            if(!result)
            {
                throw new Exception("Error deleting category");
            }
            return Ok();
        }
    }
}
