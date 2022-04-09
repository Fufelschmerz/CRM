using System;

namespace CRM.Domain.Users.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        private const string DefaultMessage = "The user already exists";

        public UserAlreadyExistsException(): base(DefaultMessage)
        {

        }

        public UserAlreadyExistsException(string message) : base(message)
        {
                
        }
    }
}
