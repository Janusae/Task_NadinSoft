using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Task.Pages.auth
{
    namespace Task.Pages.auth
    {
        public class MyAccountModel : PageModel
        {

            public IActionResult OnGet()
            {
                if (TempData["InterMyAccountCertificate"] != null)
                {
                    TempData.Keep("InterMyAccountCertificate");
                    return Page();
                }
                else
                {
                    return RedirectToPage("Login2");
                }
            }
            public IActionResult OnPost()
            {
                return RedirectToPage("");
            }

        }
    }

}
