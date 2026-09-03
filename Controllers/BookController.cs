using Microsoft.AspNetCore.Mvc;
using BookTrackerApp.Data;
using BookTrackerApp.Models;

namespace BookTrackerApp.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        // READ: Menampilkan daftar buku
        public IActionResult Index()
        {
            IEnumerable<Book> bookList = _db.Books.ToList();
            return View(bookList);
        }

        // CREATE: Form Tambah Buku (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: Simpan Buku ke SQL Server (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
