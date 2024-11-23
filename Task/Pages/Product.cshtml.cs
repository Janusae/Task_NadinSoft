using DatabaseConnection.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DatabaseConnection.EntityTable;
namespace Task.Pages
{
	public class ProductModel : PageModel
	{
		private WebApplicationDBContext _dbcontext;
		public ProductModel(WebApplicationDBContext dbcontext)
		{
			_dbcontext = dbcontext;
		}

		public void OnGet()
		{
			ViewData["data"] = _dbcontext.Product.Where(x => x.Id > 0).ToList();
		}
		public void OnPost(string search)
		{
			if (!string.IsNullOrWhiteSpace(search))
			{
				var dataFilter = _dbcontext.Product.Where(x => x.Auther == search).ToList();
				ViewData["dataFiltered"] = dataFilter;
			}
			else
			{
				ViewData["dataFiltered"] = _dbcontext.Product.ToList();
			}
		}
	}
}
