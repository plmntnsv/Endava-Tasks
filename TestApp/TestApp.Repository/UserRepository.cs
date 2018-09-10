using System;
using System.Linq;
using TestApp.Common.Exceptions;
using TestApp.Common.Hashing;
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

        public UserDto GetUserById(int id)
        {
            var user = this.context.Users.Find(id) ?? throw new UserNotFoundException("User not found!");
            
            return new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public UserDto GetUserByEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("Invalid email provided!");
            }

            var user = this.context.Users.Where(u => u.Email == email.ToLower()).FirstOrDefault() ?? throw new UserNotFoundException("User not found!");

            return new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public void LoginUser(LoginUserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException("Invalid user provided!");
            }

            var user = this.context.Users.Where(u => u.Email == userDto.Email.ToLower()).FirstOrDefault() ?? throw new InvalidCredentialsException();

            if (!HashingProvider.VerifyPasswords(userDto.Password, user.Password))
            {
                throw new InvalidCredentialsException();
            }
        }

        public void RegisterUser(RegisterUserDto userDto)
        {
            var user = this.context.Users.Where(u=> u.Email == userDto.Email).FirstOrDefault();
            
            if (user == null)
            {
                var userToAdd = new User()
                {
                    Email = userDto.Email.ToLower(),
                    Password = userDto.Password
                };

                this.context.Users.Add(userToAdd);
                Save();
            }
            else
            {
                throw new UserExistsException();
            }
        }

        public void UpdateUser(UserDto userDto)
        {
            var user = this.context.Users.Find(userDto.Email) ?? throw new UserNotFoundException("User not found!");

            var userToUpdate = new User()
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email
            };

            this.context.Users.Add(userToUpdate);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
