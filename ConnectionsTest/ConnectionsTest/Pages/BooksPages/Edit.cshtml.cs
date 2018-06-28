using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectionsTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConnectionsTest.Pages.BooksPages
{
    public class EditModel : PageModel
    {
        public ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
        _db = db;
        }

        [BindProperty]
    public Books book { get; set; }
    [TempData]
    public string afterAddMessage { get; set; }
    public void OnGet( int id)
        {
        book = _db.BookItems.Find(id);
        }
    public async Task<IActionResult> OnPost()
    {
        if(ModelState.IsValid)
        {
            var bookInDb = _db.BookItems.Find(book.ID);
                bookInDb.BooksAuthor = book.BooksAuthor;


                bookInDb.BooksTitle = book.BooksTitle;


                bookInDb.StarRating = book.StarRating;

                afterAddMessage = "List item update successfully!";

                return RedirectToPage("Index");
         }
            else
            {
                return RedirectToPage();
            }
    }
    }
}