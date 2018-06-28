using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectionsTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConnectionsTest.Pages.BooksPages
{
    public class createModel : PageModel
    {
        private ApplicationDbContext _db;
        public createModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [TempData]
        public string afterAddMessage { get; set; }
        [BindProperty]
        public Books Book { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            } else
            {
                _db.BookItems.Add(Book);
                await _db.SaveChangesAsync();
                afterAddMessage = "New Book made!";
                return RedirectToPage("Index");
            }
        }
    }
}