using System;
using TestApp.Common.Models;
using TestApp.DTO;
using TestApp.Repository.Contracts;
using TestApp.Services.Contracts;

namespace TestApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public LoginUserViewModel GetUserByEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("Invalid email provided!");
            }

            var user = repository.GetUserByEmail(email);

            return new LoginUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                PasswordHash = user.PasswordHash
            };
        }

        public LoggedUserViewModel GetUserById(int id)
        {
            var user = repository.GetUserById(id);

            return new LoggedUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = user.PasswordHash
            };
        }

        public LoginUserViewModel LoginUser(LoginUserViewModel userToLogin)
        {
            if (userToLogin == null)
            {
                throw new ArgumentNullException("Invalid user provided!");
            }

            var userDto = new LoginUserDto()
            {
                Email = userToLogin.Email,
                PasswordHash = userToLogin.PasswordHash
            };

            var returnedUser = repository.LoginUser(userDto);

            return new LoginUserViewModel()
            {
                Id = returnedUser.Id,
                Email = returnedUser.Email,
                PasswordHash = returnedUser.PasswordHash
            };
        }

        public void LogoutUser(LoggedUserViewModel user)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(RegisterUserViewModel user)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(LoggedUserViewModel user)
        {
            throw new NotImplementedException();
        }
    }
}
