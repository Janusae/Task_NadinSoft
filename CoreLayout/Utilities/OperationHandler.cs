using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayout.Utilities
{
    public class OperationHandler
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public static OperationHandler Success(string message)
        {
            return new OperationHandler
            {
                Message = message,
                Status = (int)StatusEnum.Success
            };
        }
        public static OperationHandler Error(string message)
        {
            return new OperationHandler
            {
                Message = message,
                Status = (int)StatusEnum.Error
            };
        }
        public static OperationHandler NotFound(string message)
        {
            return new OperationHandler
            {
                Message = message,
                Status = (int)StatusEnum.NotFound
            };
        }
    }
    public enum StatusEnum
    {
        Success=200,
        Error = 204 , 
        NotFound=404 ,
    }
}
