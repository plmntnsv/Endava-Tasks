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
            repository.GetUserById(id);

            return null;
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
