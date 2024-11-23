using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreLayout.Service.Product;
using CoreLayout.DTOS.Products;
using System.Diagnostics;
namespace Task.Pages.auth
{
    namespace Task.Pages.auth
    {
        public class MyAccountModel : PageModel
        {
            public string? Username{ get; set; }
            public string Name { get; set; }
            public string ManufacturePhone { get; set; }
            public string ManufactureEmail { get; set; }

            private readonly IProductService _productService;
            public MyAccountModel(IProductService productService)
            {
                _productService = productService;
            }

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
                //ViewData["data"] = _dbcontext.User
                var one = 1;
            }
            public IActionResult OnPost(string action  , string Name , string ManufactureEmail , string ManufacturePhone)
            {
                Username = User.Identity?.Name;
                if (action == "Add")
                {
                    var addProduct = _productService.AddData(new InsertDataDTOS
                    {
                        ManufactureEmail = ManufactureEmail,
                        Name = Name,
                        ManufacturePhone = ManufacturePhone ,
                        Auther = this.Username
                    });
                    if (addProduct.Status == 200)
                    {
                        TempData["Result"] = addProduct.Message;
                        return RedirectToPage("MyAccount");
                    }
                    else
                    {
                        TempData["Error"] = addProduct.Message;
                        return RedirectToPage("MyAccount");
                    }
                }
                if(action == "Edit")
                {
                    var result = _productService.EditData(new InsertDataDTOS
                    {
                        Auther = Username,
                        Name = Name, 
                        ManufactureEmail = ManufactureEmail,
                        ManufacturePhone = ManufacturePhone
                    });
                    if (result.Status == 200) 
                    {
                        TempData["Result"] = result.Message;
                    }
                    else
                    {
                        TempData["Error"] = result.Message;
                    }
                    return RedirectToPage("MyAccount");
                }
                if (action == "Delete")
                {
                    var result = _productService.DeleteData(new InsertDataDTOS
                    {
                        Auther = Username,
                        Name = Name
                    });
                    if (result.Status == 200) 
                    {
                        TempData["Result"] = result.Message;
                        return RedirectToPage("MyAccount");
                    }
                    else
                    {
                        TempData["Error"] = result.Message;
                        return RedirectToPage("MyAccount");
                    }

                }
                else
                {
                    return RedirectToPage("MyAccount");
                }
  
                
            }

        }
    }

}
