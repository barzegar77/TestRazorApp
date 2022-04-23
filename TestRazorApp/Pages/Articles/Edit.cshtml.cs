using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestRazorApp.Data;
using TestRazorApp.Models;

namespace TestRazorApp.Pages.Articles
{
    public class EditModel : PageModel
    {
        private readonly BlogDbContext _db;

        public EditModel(BlogDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Article Article { get; set; }
        public void OnGet(int? id)
        {
            Article = _db.Articles.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Articles.Update(Article);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
