using System;
using TestApp.DTO;

namespace TestApp.Repository.Contracts
{
    public interface IUserRepository
    {
        LoggedUserDto GetUserById(int id);
        LoggedUserDto LoginUser(LoginUserDto user);
        void LogoutUser(LoggedUserDto user);
        void RegisterUser(RegisterUserDto user);
        void UpdateUser(LoggedUserDto user);
        void Save();
    }
}
