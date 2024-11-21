using CoreLayout.DTOS.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnection.DBContext;
using CoreLayout.Utilities;

namespace CoreLayout.Service.Users
{
    public class UserService : IUserService
    {
        private readonly WebApplicationDBContext _dbContext;
        public UserService(WebApplicationDBContext webApplicationDBContext)
        {
            _dbContext = webApplicationDBContext;
        }
        public void RegisterProcess(Register register)
        {
            var IsUsernameExist = _dbContext.Users.Any(x=>x.UserName == register.Username);
            var IsEmailExist = _dbContext.Users.Any(x=>x.Email == register.Email);
            if (IsUsernameExist || IsEmailExist) 
            {
                OperationHandler.Error("Your Username or Email is already exist!");
            }
            else
            {
                OperationHandler.Success("You registered successfully!");

            }
        }
    }
}
