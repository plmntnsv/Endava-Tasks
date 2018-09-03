using System;

namespace TestApp.Common.Exceptions
{
    public class UserExistsException : Exception
    {
        public UserExistsException()
            : this("User already exists!")
        {
        }

        public UserExistsException(string message) : base(message)
        {
        }

        public UserExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
