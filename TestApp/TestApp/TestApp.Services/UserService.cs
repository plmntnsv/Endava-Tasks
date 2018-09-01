using System;
using TestApp.Common.Models;
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

        public LoggedUserViewModel LoginUser(LoggedUserViewModel user)
        {
            throw new NotImplementedException();
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
