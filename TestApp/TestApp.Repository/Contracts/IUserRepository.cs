using System;
using TestApp.DTO;

namespace TestApp.Repository.Contracts
{
    public interface IUserRepository
    {
        UserDto GetUserById(int id);
        UserDto GetUserByEmail(string email);
        void LoginUser(LoginUserDto userDto);
        void RegisterUser(RegisterUserDto user);
        void UpdateUser(UserDto user);
        void Save();
    }
}
