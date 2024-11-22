using CoreLayout.DTOS.Users;
using CoreLayout.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayout.Service.Users
{
    public interface IUserService
    {
        OperationHandler RegisterProcess(RegisterDTOS register);
        OperationHandler LoginProcess(LoginDTOS login);
    }
}
