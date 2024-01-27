using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using Repository.Members;

namespace SalesRazorPagesApp.Pages
{
    public class LoginModel : PageModel
    {
        // Bui Van Kien
        [BindProperty]
        public InputModel Input { get; set; } // Input 

        // Bui Van Kien 
        // Input model 
        public class InputModel
        {
            [Required(ErrorMessage = "Can not empty")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Can not empty")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
        }

        // Bui Van Kien
        IConfiguration _configuration; // Json configuration
        IMemberRepository _memberRepo = new MemberRepository(); // Member repository

        // Bui Van Kien
        // On post 
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var account = _memberRepo
                .GetMembers()
                .Where(x => x.Password == Input.Password && x.Email == Input.Email)
                .FirstOrDefault();
            
            bool isAdmin = checkAdmin(Input.Email, Input.Password);
            if (account == null && !isAdmin)
            {
                ViewData["Message"] = "Invalid username or password";
                return Page();
            }
            else if (isAdmin)
            {
                HttpContext.Session.SetString("role", "admin");
            }
            else
            {
                HttpContext.Session.SetString("role", "member");
                HttpContext.Session.SetString("email", account.Email);
            }
            
            HttpContext.Session.SetString("email", Input.Email);
            return RedirectToPage("/MainPage");
        }

        // Bui Van Kien
        // Check is admin or not
        private bool checkAdmin(string email, string password)
        {
            bool isAdmin = false;
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            if (_configuration["Admin:Email"] == email && _configuration["Admin:Password"] == password)
            {
                isAdmin = true;
            }
            return isAdmin;
        }
    }
}
