using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestRazorApp.Data;
using TestRazorApp.Models;

namespace TestRazorApp.Pages.Articles
{
    public class DetailsModel : PageModel
    {
        private readonly BlogDbContext _context;

        public DetailsModel(BlogDbContext context)
        {
            _context = context;
        }

        public Article Article { get; set; }

        public void OnGet(int? id)
        {
            Article = _context.Articles.Find(id);

        }
    }
}
