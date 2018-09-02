﻿using System;
using System.Linq;
using TestApp.Common.Exceptions;
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
            var user = this.context.Users.Find(id) ?? throw new UserNotFoundException("User not found!");
            
            return new LoggedUserDto()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = user.Password
            };
        }

        public LoginUserDto GetUserByEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("Invalid email provided!");
            }

            var user = this.context.Users.Where(u => u.Email == email.ToLower()).FirstOrDefault() ?? throw new UserNotFoundException("User not found!");

            return new LoginUserDto()
            {
                Id = user.Id,
                Email = user.Email,
                PasswordHash = user.Password
            };
        }

        public LoginUserDto LoginUser(LoginUserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException("Invalid user provided!");
            }

            var user = this.context.Users.Where(u => u.Email == userDto.Email.ToLower()).FirstOrDefault() ?? throw new UserNotFoundException("User not found!");

            if (userDto.PasswordHash != user.Password)
            {
                throw new InvalidCredentialsCombinationException("Wrong email and/or password!");
            }

            return new LoginUserDto()
            {
                Id = user.Id,
                Email = user.Email,
                PasswordHash = user.Password
            };
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
                throw new UserExistsException("User already exists!");
            }
        }

        public void UpdateUser(LoggedUserDto userDto)
        {
            var user = this.context.Users.Find(userDto.Email) ?? throw new UserNotFoundException("User not found!");

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
