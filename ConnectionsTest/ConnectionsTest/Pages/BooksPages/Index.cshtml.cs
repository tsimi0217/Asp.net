using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectionsTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConnectionsTest.Pages.BooksPages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;
        [TempData]
        public string afterAddMessage { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Books> myBooks { get; set; }

       
        public async Task OnGet()
        {
            myBooks = await _db.BookItems.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var theBook = _db.BookItems.Find(id);
            _db.BookItems.Remove(theBook);
            await _db.SaveChangesAsync();
            afterAddMessage = "Book deleted successfully!";
            return RedirectToPage();
        }
    }
}