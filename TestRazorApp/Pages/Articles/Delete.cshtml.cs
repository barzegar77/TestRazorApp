using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestRazorApp.Data;
using TestRazorApp.Models;

namespace TestRazorApp.Pages.Articles
{
    public class DeleteModel : PageModel
    {
        private readonly BlogDbContext _db;

        public DeleteModel(BlogDbContext db)
        {
            _db = db;
        }

        public Article Article { get; set; }

        public void OnGet(int? id)
        {
            Article = _db.Articles.Find(id);
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            if (ModelState.IsValid)
            {
                var article = await _db.Articles.FindAsync(id);
                _db.Articles.Remove(article);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
