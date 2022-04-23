using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestRazorApp.Data;
using TestRazorApp.Models;

namespace TestRazorApp.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly BlogDbContext _db;

        public CreateModel(BlogDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Article Article { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Articles.AddAsync(Article);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
