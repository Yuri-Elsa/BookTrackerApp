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

        // EDIT: Form Edit Buku (GET)
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // EDIT: Simpan Perubahan Buku (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Books.Update(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // DELETE: Konfirmasi Hapus Buku (GET)
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // DELETE: Hapus Buku dari Database (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _db.Books.Find(id);
            if (book != null)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // TOGGLE: Tandai buku sudah/belum dibaca langsung dari daftar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleRead(int id)
        {
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            book.IsRead = !book.IsRead;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}