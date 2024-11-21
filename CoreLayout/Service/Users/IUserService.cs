using CoreLayout.DTOS.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayout.Service.Users
{
    public interface IUserService
    {
        void RegisterProcess(Register register);
    }
}
