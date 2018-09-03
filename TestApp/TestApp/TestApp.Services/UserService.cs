using System;
using TestApp.Common.Models;
using TestApp.DTO;
using TestApp.Repository.Contracts;
using TestApp.Services.Contracts;

namespace TestApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public LoginUserViewModel GetUserByEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("Invalid email provided!");
            }

            var user = userRepository.GetUserByEmail(email);

            return new LoginUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
            };
        }

        public UserViewModel GetUserById(int id)
        {
            var user = userRepository.GetUserById(id);

            return new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public void LoginUser(LoginUserViewModel userToLogin)
        {
            if (userToLogin == null)
            {
                throw new ArgumentNullException("Invalid user provided!");
            }

            var userDto = new LoginUserDto()
            {
                Email = userToLogin.Email,
                Password = userToLogin.Password
            };

           userRepository.LoginUser(userDto);
        }

        public void RegisterUser(RegisterUserViewModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Provided user is null!");
            }

            var userDto = new RegisterUserDto()
            {
                Email = user.Email,
                Password = user.Password
            };

            this.userRepository.RegisterUser(userDto);
        }

        public void Save()
        {
            this.userRepository.Save();
        }

        public void UpdateUser(UserViewModel user)
        {
            throw new NotImplementedException();
        }
    }
}
