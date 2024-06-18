using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt.Dto.Authors;
using Projekt.Model.Entities;
using Projekt.Model;
using Projekt.Repository.Publishers;
using Projekt.Dto.Publishers;
using AutoMapper;

namespace Projekt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        
        private readonly IPublisherRepository _publisherRepository;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public PublishersController(IPublisherRepository publisherRepository, AppDbContext dbContext, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var publisher = await _publisherRepository.GetPublisherByIdAsync(id);


            if (publisher == null)
            {
                return NotFound();
            }
            var publisherDto = _mapper.Map<PublisherDto>(publisher);
            return Ok(publisherDto);
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var publishers = await _publisherRepository.GetPublishersByNameAsync(name);
            if (!publishers.Any())
            {
                return NotFound();
            }
            var publisherDto = _mapper.Map<List<PublisherDto>>(publishers);
            return Ok(publisherDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var publishers = await _publisherRepository.GetAllPublishersAsync();
            if (!publishers.Any())
            {
                return NotFound();
            }
            var publishersDto = _mapper.Map<List<PublisherDto>>(publishers);
            return Ok(publishersDto);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PublishersInputDto publisher)
        {
            if (publisher == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var books = new List<Book>();

            foreach (var bookId in publisher.BooksId)
            {
                var book = _dbContext.Books.FirstOrDefault(a => a.Id == bookId);
                if (book != null)
                {
                    books.Add(book);
                }
            }
            var authors= new List<Author>();

            if (publisher.AuthorsId != null)
            {

                foreach (var authorsId in publisher.AuthorsId)
                {
                    var author = _dbContext.Authors.FirstOrDefault(a => a.Id == authorsId);
                    if (author != null)
                    {
                        authors.Add(author);
                    }
                }
            }

            var newPublisher= new Publisher()
            {
                Name = publisher.Name,
                Books = books.Any() ? books : null,
                Authors = authors.Any() ? authors : null

            };


            var result = await _publisherRepository.SavePublisherAsync(newPublisher);
            if (!result)
            {
                throw new Exception("Error saving book");
            }
            var publisherDto = _mapper.Map<PublisherDto>(newPublisher);
            return Ok(publisherDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PublishersInputDto publisher)
        {

            if (publisher == null)
            {
                return BadRequest();

            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var existingPublisher = await _publisherRepository.GetPublisherByIdAsync(id);

            if (existingPublisher == null)
            {
                return NotFound();
            }

            var books = new List<Book>();

            foreach (var bookId in publisher.BooksId)
            {
                var book = _dbContext.Books.FirstOrDefault(a => a.Id == bookId);
                if (book != null)
                {
                    books.Add(book);
                }
            }
            var authors = new List<Author>();

            if (publisher.AuthorsId != null)
            {

                foreach (var authorsId in publisher.AuthorsId)
                {
                    var author = _dbContext.Authors.FirstOrDefault(a => a.Id == authorsId);
                    if (authors != null)
                    {
                        authors.Add(author);
                    }
                }
            }
            existingPublisher.Name = publisher.Name;
            existingPublisher.Books = publisher == null ? null : existingPublisher.Books; ;
            existingPublisher.Authors = authors == null ? null : existingPublisher.Authors;


            var result = await _publisherRepository.SavePublisherAsync(existingPublisher);
            if (!result)
            {
                throw new Exception("error updating author");
            }
            var publisherDto = _mapper.Map<PublisherDto>(existingPublisher);
            return Ok(publisherDto);


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var existingAuthor = await _publisherRepository.GetPublisherByIdAsync(id);
            if (existingAuthor == null)
                return NotFound();

            var result = await _publisherRepository.DeletePublisherAsync(id);
            if (!result)
            {
                throw new Exception("Error deleting Author");
            }
            return Ok();

        }
        
    }
}
