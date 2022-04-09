namespace CRM.Application.Infrastructure.Exceptions.Users
{
    using System;

    public class UserNotFoundException : ApplicationException
    {
        private const string DefaultMessage = "User not found";

        public UserNotFoundException() : base(DefaultMessage)
        {

        }

        public UserNotFoundException(string message) : base(message)
        {

        }
    }
}
