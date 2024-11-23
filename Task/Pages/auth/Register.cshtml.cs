using CoreLayout.DTOS.Users;
using CoreLayout.Service.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using CoreLayout.DTOS.Users;
using DatabaseConnection.DBContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
namespace Task.Pages.auth
{


    namespace Task.Pages.auth
    {
        public class RegisterModel : PageModel
        {
            private readonly IUserService _userService;
            private readonly WebApplicationDBContext _context;

            public RegisterModel(IUserService userService)
            {
                _userService = userService;
            }
            public string Username { get; set; }
            public string Fullname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }

            public void OnGet()
            {
            }


            public IActionResult OnPost(string Username, string Fullname, string Email, string Password, string ConfirmPassword)
            {
                var data = _userService.RegisterProcess(new RegisterDTOS()
                {
                    Username = Username,
                    Fullname = Fullname,
                    Email = Email,
                    Password = Password,
                    ConfirmPassword = ConfirmPassword
                });

                if (data.Status == 200)
                {
                    return RedirectToPage("Login2");
                }
                else
                {
                    if (data != null)
                    {
                        TempData["Error"] = $"{data.Message}";
                    }
                    
                    return RedirectToPage("Register");
                }
                
            }


        }

    }

}

