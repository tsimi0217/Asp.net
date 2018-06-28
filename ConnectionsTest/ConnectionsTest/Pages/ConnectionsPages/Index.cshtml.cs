using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectionsTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConnectionsTest.Pages.ConnectionsPages
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
        public IEnumerable<Connections>myConnections { get; set; }

        public async Task OnGet()
        {
            myConnections = await _db.ConnectionItems.ToListAsync();

        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var theConnection = _db.ConnectionItems.Find(id);
            _db.ConnectionItems.Remove(theConnection);
            await _db.SaveChangesAsync();
            afterAddMessage = "Connection deleted successfully!";
            return RedirectToPage();
        }
    }
}