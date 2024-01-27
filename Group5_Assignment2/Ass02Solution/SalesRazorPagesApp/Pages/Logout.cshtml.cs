using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SalesRazorPagesApp.Pages
{
    public class LogoutModel : PageModel
    {
        // Bui Van Kien 
        // On get
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}
