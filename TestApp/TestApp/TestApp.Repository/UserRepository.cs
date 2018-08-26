using System;
using TestApp.DAL;
using TestApp.DTO;
using TestApp.Repository.Contracts;

namespace TestApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TestDbContext context;

        public UserRepository(TestDbContext context)
        {
            this.context = context;
        }

        public LoggedUserDto GetUserById(int id)
        {
            var user = this.context.Users.Find(id) ?? throw new ArgumentNullException("User not found!");
            
            return new LoggedUserDto()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = user.Password
            };
        }

        public LoggedUserDto LoginUser(LoginUserDto user)
        {
            throw new NotImplementedException();
        }

        public void LogoutUser(LoggedUserDto user)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(RegisterUserDto userDto)
        {
            var user = this.context.Users.Find(userDto.Email);
            
            if (user == null)
            {
                var userToAdd = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    Password = userDto.Password
                };

                this.context.Users.Add(userToAdd);
            }
            else
            {
                throw new ArgumentException("User already exists!");
            }
        }

        public void UpdateUser(LoggedUserDto userDto)
        {
            var user = this.context.Users.Find(userDto.Email) ?? throw new ArgumentNullException("User not found!");

            var userToUpdate = new User()
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.PasswordHash
            };

            this.context.Users.Add(userToUpdate);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
