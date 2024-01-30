using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SalesRazorPagesApp.Pages.MemberPages.Profile
{
    public class MemberProfileModel : PageModel
    {
        private readonly eStoreContext _context;
        [BindProperty]
        public Member member { get; set; }
        public MemberProfileModel(eStoreContext context)
        {
            _context = context;
        }
       
        public async Task<IActionResult> OnGetAsync()
        {
            // L?y th�ng tin ng??i d�ng hi?n t?i (?i?u n�y ph?i ???c x�c ??nh theo nhu c?u c?a b?n)
            // Thay th? b?ng ID ng??i d�ng th?c t?
            int currentUserId=1;
            
            member = await _context.Members.FirstOrDefaultAsync(m=>m.MemberId == currentUserId);

            if (member==null)
            {
                return NotFound($"Not found member with ID '{currentUserId}'.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // L?u th�ng tin ng??i d�ng ???c c?p nh?t
            _context.Members.Update(member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./MemberProfile"); // Chuy?n h??ng sau khi c?p nh?t th�nh c�ng
        }


    }
}
