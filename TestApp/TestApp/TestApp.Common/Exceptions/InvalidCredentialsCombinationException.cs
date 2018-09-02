using System;

namespace TestApp.Common.Exceptions
{
    public class InvalidCredentialsCombinationException : Exception
    {
        public InvalidCredentialsCombinationException()
        {
        }

        public InvalidCredentialsCombinationException(string message) : base(message)
        {
        }

        public InvalidCredentialsCombinationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
