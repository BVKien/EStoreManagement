using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SalesRazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // Bui Van Kien
        // On get 
        public IActionResult OnGet() // if void 
        {
            return RedirectToPage("/Login"); // if Empty 
        }
    }
}