using CoreLayout.DTOS.Products;
using CoreLayout.Utilities;
using DatabaseConnection.EntityTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayout.Service.Product
{
	public interface IProductService
	{
		OperationHandler AddData(InsertDataDTOS  insertDOTS);
		OperationHandler EditData(InsertDataDTOS  insertDOTS);
		OperationHandler DeleteData(InsertDataDTOS  insertDOTS);
		List<object> ShowData(string Name);
	}
}
