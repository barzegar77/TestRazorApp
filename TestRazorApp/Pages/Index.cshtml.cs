using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestRazorApp.Data;
using TestRazorApp.Models;

namespace TestRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BlogDbContext _db;

        public IndexModel(BlogDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Article> Articles { get; set; }

        public void OnGet()
        {
            Articles = _db.Articles;
        }

    }
}