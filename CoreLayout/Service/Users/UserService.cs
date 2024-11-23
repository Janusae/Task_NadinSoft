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
            try
            {
                var IsUsernameExist = _dbContext.Users.Any(x => x.UserName == register.Username);
                var IsEmailExist = _dbContext.Users.Any(x => x.Email == register.Email);
                if (IsUsernameExist || IsEmailExist)
                {
                    return OperationHandler.Error("Your Username or Email is already exist!");
                }
                else
                {
                    if (register.Fullname == null)
                    {
                        return OperationHandler.Error("You must enter your full name!");
                    }
                    else
                    {
                        if (register.Password == register.ConfirmPassword)
                        {
                            _dbContext.Users.Add(new DatabaseConnection.EntityTable.User
                            {
                                Email = register.Email,
                                UserName = register.Username,
                                Fullname = register.Username,
                                Password = register.Password,

                            });
                            _dbContext.SaveChanges();

                            return OperationHandler.Success("You registered successfully!");
                        }
                        else
                        {
                            return OperationHandler.Error("Your Passwords are not the same!");

                        }
                    }



                }
            }
            catch (Exception ex) 
            {
                return OperationHandler.NotFound("Your username or password are not correct!");
            }
            
        }
        public OperationHandler LoginProcess(LoginDTOS loginInput)
        {
            
            var UserValidation = _dbContext.Users.FirstOrDefault(x => x.Id > 0);
            var PasswdValidation = UserValidation.Password == loginInput.Password;
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





    }

}


