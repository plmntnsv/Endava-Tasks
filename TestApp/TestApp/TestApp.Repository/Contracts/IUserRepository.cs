using System;
using TestApp.DTO;

namespace TestApp.Repository.Contracts
{
    public interface IUserRepository
    {
        LoggedUserDto GetUserById(int id);
        LoginUserDto GetUserByEmail(string email);
        void LoginUser(LoginUserDto userDto);
        void RegisterUser(RegisterUserDto user);
        void UpdateUser(LoggedUserDto user);
        void Save();
    }
}
