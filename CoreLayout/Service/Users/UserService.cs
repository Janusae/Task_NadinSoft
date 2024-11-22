using CoreLayout.DTOS.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnection.DBContext;
using DatabaseConnection.EntityTable;
using CoreLayout.Utilities;
using System.Security.Claims;
using System.Net.Http;
using System.ComponentModel.DataAnnotations;
namespace CoreLayout.Service.Users
{
    public class UserService : IUserService
    {
        private readonly WebApplicationDBContext _dbContext;

        public UserService(WebApplicationDBContext webApplicationDBContext)
        {
            _dbContext = webApplicationDBContext;
        }
        public OperationHandler RegisterProcess(RegisterDTOS register)
        {
            var IsUsernameExist = _dbContext.Users.Any(x => x.UserName == register.Username);
            var IsEmailExist = _dbContext.Users.Any(x => x.Email == register.Email);
            if (IsUsernameExist || IsEmailExist)
            {
                return OperationHandler.Error("Your Username or Email is already exist!");
            }
            else
            {
                if (register.Password == register.ConfirmPassword)
                {
                    _dbContext.Users.Add(new DatabaseConnection.EntityTable.Users
                    {
                        Email = register.Email,
                        UserName = register.Username,
                        Fullname = register.Username,
                        IsDelete = 0,
                        UserRole = UserRole.User,
                        Password = register.Password,

                    });
                    _dbContext.SaveChanges();

                    return OperationHandler.Success("You registered successfully!");
                }
                else
                {
                    return OperationHandler.Error("Your Password are not the same!");

                }


            }
        }
        public OperationHandler LoginProcess(LoginDTOS login)
        {
            try
            {
                var UserValidation = _dbContext.Users.FirstOrDefault(x => x.UserName == login.Username);
                var one = 1;
                var PasswdValidation = UserValidation.Password == login.Password;
                if (UserValidation != null || PasswdValidation == true)
                {

                    return new OperationHandler
                    {
                        Message = "You are loggined successfully!",
                        Status = (int)StatusEnum.Success

                    };
                }
                else
                {
                    return new OperationHandler
                    {
                        Message = "You are not loggined successfully!",
                        Status = (int)StatusEnum.Error

                    };
                }
            }
            catch (Exception ex)
            {
                return OperationHandler.NotFound("We could not find your Username");
            }




        }

    }
}
