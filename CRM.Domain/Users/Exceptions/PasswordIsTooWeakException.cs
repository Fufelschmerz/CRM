using System;

namespace CRM.Domain.Users.Exceptions
{
    public class PasswordIsTooWeakException : Exception
    {
        private const string DefaultMessage = "The password is very weak";

        public PasswordIsTooWeakException() : base(DefaultMessage)
        {

        }

        public PasswordIsTooWeakException(string message) : base(message)
        {

        }
    }
}
