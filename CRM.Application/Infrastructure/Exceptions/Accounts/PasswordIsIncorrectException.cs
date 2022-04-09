namespace CRM.Application.Infrastructure.Exceptions.Accounts
{
    using System;
    public class PasswordIsIncorrectException : ApplicationException
    {
        private const string DefaultMessage = "Password is incorrent";

        public PasswordIsIncorrectException() :base(DefaultMessage)
        {

        }

        public PasswordIsIncorrectException(string message) :base(message)
        {
            
        }
    }
}