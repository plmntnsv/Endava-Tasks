using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Common.Models;

namespace TestApp.Services.Contracts
{
    public interface IUserService
    {
        UserViewModel GetUserById(int id);
        LoginUserViewModel GetUserByEmail(string email);
        void LoginUser(LoginUserViewModel userToLogin);
        void RegisterUser(RegisterUserViewModel user);
        void UpdateUser(UserViewModel user);
        void Save();
    }
}
