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
        LoggedUserViewModel GetUserById(int id);
        LoginUserViewModel GetUserByEmail(string email);
        void LoginUser(LoginUserViewModel userToLogin);
        void RegisterUser(RegisterUserViewModel user);
        void UpdateUser(LoggedUserViewModel user);
        void Save();
    }
}
