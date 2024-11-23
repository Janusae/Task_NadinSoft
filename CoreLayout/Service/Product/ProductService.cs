using CoreLayout.DTOS.Products;
using CoreLayout.Utilities;
using DatabaseConnection.DBContext;
using DatabaseConnection.EntityTable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayout.Service.Product
{
	public class ProductService : IProductService
	{
		private readonly WebApplicationDBContext _dbcontext;

		public ProductService(WebApplicationDBContext dbcontext)
		{
			_dbcontext = dbcontext;
		}

		public OperationHandler EditData(InsertDataDTOS insertDOTS)
		{
			var IsExistEmail = _dbcontext.Product.Any(x=>x.ManufactureEmail == insertDOTS.ManufactureEmail);
			if (!IsExistEmail) 
			{
				var IsCorrectInfo = insertDOTS.Name != null && insertDOTS.ManufactureEmail != null && insertDOTS.ManufacturePhone != null;

				if (IsCorrectInfo)
				{
					var search = _dbcontext.Product.FirstOrDefault(x => x.Auther == insertDOTS.Auther && x.Name == insertDOTS.Name);
					if (search != null)
					{
						try
						{
							search.Name = insertDOTS.Name;
							search.ManufacturePhone = insertDOTS.ManufacturePhone;
							search.ManufactureEmail = insertDOTS.ManufactureEmail;
							search.IsAvailable = insertDOTS.IsAvailable;
							_dbcontext.SaveChanges();
							return OperationHandler.Success("You updated the product successfully!");
						}
						catch (Exception ex)
						{
							return OperationHandler.Error(ex.Message);
						}
					}
					else
					{
						return OperationHandler.NotFound("We could not find your product");
					}
				}
				else
				{
					return OperationHandler.Error("Your information is not correct!");
				}
			}
			else
			{
				return OperationHandler.Error("Your email is repeated!");
			}
			
		}

		public OperationHandler DeleteData(InsertDataDTOS insertDOTS)
		{
			var IsCorrectInfo = insertDOTS.Name != null && insertDOTS.Auther != null;
			if (IsCorrectInfo)
			{
				var search = _dbcontext.Product.FirstOrDefault(x => x.Auther == insertDOTS.Auther && x.Name == insertDOTS.Name);
				if (search != null)
				{
					try
					{
						_dbcontext.Product.Remove(search);
						_dbcontext.SaveChanges();
						return OperationHandler.Success("The product removed!");
					}
					catch (Exception ex)
					{
						return OperationHandler.Error(ex.Message);
					}
				}
				else
				{
					return OperationHandler.NotFound("We could not find any Product with that name!");
				}
			}
			else
			{
				return OperationHandler.Error("Your information is not correct!");
			}
		}

		public OperationHandler AddData(InsertDataDTOS insertDOTS)
		{
			var CheckEmail = _dbcontext.Product.Any(x => x.ManufactureEmail == insertDOTS.ManufactureEmail);
			if (!CheckEmail)
			{
				var IsCorrectInfo = insertDOTS.Name != null && insertDOTS.ManufactureEmail != null && insertDOTS.ManufacturePhone != null;

				if (IsCorrectInfo)
				{
					try
					{
						_dbcontext.Add(new ProductModel
						{
							IsAvailable = true,
							IsDelete = false,
							ManufactureEmail = insertDOTS.ManufactureEmail,
							ManufacturePhone = insertDOTS.ManufacturePhone,
							Name = insertDOTS.Name,
							ProduceDate = DateTime.Now,
							Auther = insertDOTS.Auther
						});
						_dbcontext.SaveChanges();
						return OperationHandler.Success("You added a new product successfully!");
					}
					catch (Exception ex)
					{
						return OperationHandler.Error(ex.Message);
					}
				}
				else
				{
					return OperationHandler.Error("Your information is not correct!");
				}
			}
			else
			{
				return OperationHandler.Error("The email is repeated!");
			}
		}

		public List<object> ShowData(string Name)
		{
			var search = _dbcontext.Product.Where(x => x.Auther == Name).ToArray();
			var check = 0;
			return [];
		}
	}
}
