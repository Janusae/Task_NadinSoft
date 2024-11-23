using CoreLayout.DTOS.Users;
using CoreLayout.Service.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Task.Pages.auth
{
	namespace Task.Pages.auth
	{
		public class Login2Model : PageModel
		{
			private readonly IUserService _userService;
			public Login2Model(IUserService userService)
			{
				_userService = userService;
			}
			public string Username { get; set; }
			public string Password { get; set; }
			public void OnGet()
			{
			}
			public IActionResult OnPost(string Username, string Password)
			{
				var proccess = _userService.LoginProcess(new LoginDTOS
				{
					Username = Username,
					Password = Password
				});
				if (proccess.Status == 200)
				{
					var status = LoginProcess(Username);
					TempData["InterMyAccountCertificate"] = true;
					return RedirectToPage("MyAccount");
				}
				else
				{
					TempData["Error"] = "Your information is not correct!";
					return RedirectToPage("Login2");
				}
			}
			public async Task<Status> LoginProcess(string username)
			{
				var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, username),  // Name claim
                        new Claim(ClaimTypes.NameIdentifier, username),  // User Identifier
                        new Claim(ClaimTypes.Role, "User")  // User role claim
                    };
				var identity = new ClaimsIdentity(claims, "login");
				var principal = new ClaimsPrincipal(identity);
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
				return Status.success;
			}
			public enum Status
			{
				success
			}
		}
	}
}
