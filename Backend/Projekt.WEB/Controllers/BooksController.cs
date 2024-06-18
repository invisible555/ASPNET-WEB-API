using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Projekt.Model;
using Projekt.Model.Entities;
using System.Threading.Tasks;

namespace Projekt.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
            return View(books);
        }

  
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}
